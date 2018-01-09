var PPM = function PrivacyPolicyModel(url, initialState) {
    var self = this;

    var urlUpdate = url;
    self.OspPolicyId = initialState.OspPolicyId;

    var hashString = function (str) {
        // Return an integer hash for a string
        // Based on http://werxltd.com/wp/2010/05/13/javascript-implementation-of-javas-string-hashcode-method/
        var hash = 0;
        if (str === undefined || str === null || str.length == 0) return hash;
        for (var i = 0; i < str.length; i++) {
            var ch = str.charCodeAt(i);
            hash = ((hash << 5) - hash) + ch;
            hash = hash & hash; // Convert to 32bit integer
        }
        return hash;
    };

    var AccessPolicy = function (Reasonid, Datauser, Datasubjecttype, Datatype, Reason, IsEditable) {
        this.Reasonid = ko.observable(Reasonid);
        this.Datauser = ko.observable(Datauser);
        this.Datasubjecttype = ko.observable(Datasubjecttype);
        this.Datatype = ko.observable(Datatype);
        this.Reason = ko.observable(Reason);

        // Add an id to uniquely identify an access policy.
        // Must be of a type storablein in a data field of a HTML element
        this.Id = ko.pureComputed(function () {
            var prime = 31;
            var result = 1;

            result = prime * result + hashString(this.Reasonid());
            result = prime * result + hashString(this.Datauser());
            result = prime * result + hashString(this.Datasubjecttype());
            result = prime * result + hashString(this.Datatype());
            result = prime * result + hashString(this.Reason());
            return result;
        }, this);

        if (IsEditable) {
            this.EditableCopy = new EditableAccessPolicy(this);
        }
    }

    var EditableAccessPolicy = function (policy) {
        var editable = new AccessPolicy(policy.Reasonid(), policy.Datauser(), policy.Datasubjecttype(), policy.Datatype(), policy.Reason(), false);
        editable.Editing = ko.observable(false);
        return editable;
    };

    // Convert the JS objects into observable AccessPolicies
    var policies = [];
    for (var i = 0; i < initialState.Policies.length; i++) {
        var policy = initialState.Policies[i];
        policies[i] = new AccessPolicy(policy.Reasonid, policy.Datauser, policy.Datasubjecttype, policy.Datatype, policy.Reason, true);
    }
    self.policies = ko.observableArray(policies);

    self.newPolicy = new EditableAccessPolicy(new AccessPolicy("", "", "", "", ""));
    self.newPolicy.Editing(true);

    self.addPolicy = function () {
        var newPolicy = new AccessPolicy(self.newPolicy.Reasonid(), self.newPolicy.Datauser(), self.newPolicy.Datasubjecttype(), self.newPolicy.Datatype(), self.newPolicy.Reason(), true);
        self.policies.push(newPolicy);

        self.newPolicy.Reasonid("");
        self.newPolicy.Datauser("");
        self.newPolicy.Datasubjecttype("");
        self.newPolicy.Datatype("");
        self.newPolicy.Reason("");
    }

    self.removePolicy = function (id) {
        self.policies.remove(function (item) {
            return item.Id() === id
        });
    }

    this.addNewPolicy = function () {
        if (doesIdExist(self.newPolicy.Id())) {
            showAlert("There is already a policy with these values.");
            return;
        }

        // Don't want to the update the view until the add has succeeded,
        // so create a temp data object from the model's JSON
        // and use that to produce the JSON for the desired state.
        var snapshot = ko.toJSON(self);
        var temp = JSON.parse(snapshot);
        temp.policies.push(temp.newPolicy);

        $.ajax({
            url: urlUpdate,
            method: "PUT",
            data: JSON.stringify(temp),
            contentType: "application/json"
        })
        .done(function () {
            self.addPolicy();
            // Just init all the confirmations rather than trying
            // to find the new one specifically
            $('[data-toggle=confirmation]').confirmation({
                rootSelector: '[data-toggle=confirmation]'
            });
        })
        .fail(function () {
            showAlert("The policy could not be added. Please try again.");
        });
    }.bind(this);

    this.updatePolicy = function (policy) {
        if (doesIdExist(policy.EditableCopy.Id())) {
            showAlert("Update, there is already a policy with these values." + " " + self.OspPolicyId + " " + policy.EditableCopy.Reason());
            return;
        }

        // Create JSON having the appropriate policy updated
        // with the new values
        var snapshot = ko.toJSON(self);
        var tempUrl = "/OspAdmin/UpdatePrivacyPolicyReason";
        //alert("new url " + tempUrl);
        var temp = JSON.parse(snapshot);
        var singlep = { 'OspPolicyId': temp.OspPolicyId, policies: [{Reasonid: "", Datauser: "", Datasubjecttype: "", Datatype: "", Reason: ""}]};
        for (var i = 0; i < temp.policies.length ; i++) {
            if (temp.policies[i].Id === policy.Id()) {
                temp.policies[i].Reasonid = policy.EditableCopy.Reasonid();
                temp.policies[i].Datauser = policy.EditableCopy.Datauser();
                temp.policies[i].Datasubjecttype = policy.EditableCopy.Datasubjecttype();
                temp.policies[i].Datatype = policy.EditableCopy.Datatype();
                temp.policies[i].Reason = policy.EditableCopy.Reason();

                //singlep.policies[0].Id = policy.Id();
                singlep.policies[0].Reasonid = policy.EditableCopy.Reasonid();
                singlep.policies[0].Datauser = policy.EditableCopy.Datauser();
                singlep.policies[0].Datasubjecttype = policy.EditableCopy.Datasubjecttype();
                singlep.policies[0].Datatype = policy.EditableCopy.Datatype();
                singlep.policies[0].Reason = policy.EditableCopy.Reason();
                
                break;
            }
        }

        $.ajax({
            url: tempUrl,
            method: "PUT",
            contentType: "application/json",
            //data: JSON.stringify(temp)
            data: JSON.stringify(singlep)
        })
        .done(function () {
            policy.Reasonid(policy.EditableCopy.Reasonid());
            policy.Datauser(policy.EditableCopy.Datauser());
            policy.Datasubjecttype(policy.EditableCopy.Datasubjecttype());
            policy.Datatype(policy.EditableCopy.Datatype());
            policy.Reason(policy.EditableCopy.Reason());

            policy.EditableCopy.Editing(false);
        })
        .fail(function () {
            showAlert("The regulation could not be updated. Please try again.");
        });
    }.bind(this);

    this.deletePolicy = function () {
        var id = $(this).data("id");
        showAlert("deleting " + id);

        var snapshot = ko.toJSON(self);
        var temp = JSON.parse(snapshot);
        var policiesAfterDelete = [];
        // New state will only include policies
        // for which the id does not match
        // that of the deleted policy, e.g.
        // they differ in some way
        for (var i = 0; i < temp.policies.length ; i++) {
            if (temp.policies[i].Id !== id) {
                policiesAfterDelete.push(temp.policies[i]);
            }
        }
        temp.policies = policiesAfterDelete;

        $.ajax({
            url: urlUpdate,
            method: "PUT",
            contentType: "application/json",
            data: JSON.stringify(temp)
        })
        .done(function (data) {
            self.removePolicy(id);
        })
        .fail(function () {
            showAlert("The private policy could not be deleted. Please try again.");
        });
    }.bind(this);

    function doesIdExist(id) {
        // Check that no existing policy has the Id
        var existingIds = $.map(self.policies(), function (p) { return p.Id() });
        return existingIds.indexOf(id) > -1;
    }
}

var OperandoPrivacyPolicy = function () {
    var urlUpdate;
    var policyModel;

    function deletePolicy() {
        var id = $(this).data("id");
        var ospid = $(this).data("osp");
        var idx = 0;
        for (var i = 0; i < policyModel.opps.length; i++) {
            if (policyModel.opps[i].OspPolicyId == ospid) {
                idx = i;
                break;
            }
        }

        var snapshot = ko.toJSON(policyModel.opps[idx]);
        var temp = JSON.parse(snapshot);
        var policiesAfterDelete = [];
        // New state will only include policies 
        // for which the id does not match 
        // that of the deleted policy, e.g.
        // they differ in some way
        for (var i = 0; i < temp.policies.length ; i++) {
            if (temp.policies[i].Id !== id) {
                policiesAfterDelete.push(temp.policies[i]);
            }
        }
        temp.policies = policiesAfterDelete;

        $.ajax({
            url: urlUpdate,
            method: "PUT",
            contentType: "application/json",
            data: JSON.stringify(temp)
        })
        .done(function (data) {
            policyModel.opps[idx].removePolicy(id);
        })
        .fail(function () {
            showAlert("The private policy could not be deleted. Please try again.");
        });
    }

    return {
        // Setup with the update url, the osp id, and the initial state
        init: function (_urlUpdate, ospsList) {
            urlUpdate = _urlUpdate;
            var osps = [];
            for (var i = 0; i < ospsList.length; i++) {
                osps.push(new PPM(urlUpdate, ospsList[i]));
            }
            policyModel = { opps: osps };
            ko.applyBindings(policyModel);
        },
        //addPolicy: addPolicy,
        //updatePolicy: updatePolicy,
        deletePolicy: deletePolicy
    };
}();

function showAlert(msg) {
    $("#alertModalBody").text(msg);
    $("#alertModal").modal();
}