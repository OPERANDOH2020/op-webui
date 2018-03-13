var OperandoRegulations = function () {
    // Functions which take a regulation id as a
    // parameter and return the action url to use
    var urlAdd;
    var urlUpdate;
    var urlDelete;

    //The regulations model
    var regModel;

    function RegulationModel(initialState) {
        var self = this;

        var Regulation = function (RegId, LegislationSector, Reason, PrivateInformationType, Action, RequiredConsent, IsEditable) {
            this.RegId = ko.observable(RegId);
            this.LegislationSector = ko.observable(LegislationSector);
            this.Reason = ko.observable(Reason);
            this.PrivateInformationType = ko.observable(PrivateInformationType);
            this.Action = ko.observable(Action);
            this.RequiredConsent = ko.observable(RequiredConsent);

            if(IsEditable){
                this.EditableCopy = new EditableRegulation(this);
            }
        };

        var EditableRegulation = function(regulation){
            var editable = new Regulation(regulation.RegId(), regulation.LegislationSector(), regulation.Reason(), 
                regulation.PrivateInformationType(), regulation.Action(), regulation.RequiredConsent(), false);
            editable.Editing = ko.observable(false);
            return editable;
        };

        // Convert the JS objects into observable Regulations
        var regulations = [];
        for(var i = 0;  i < initialState.length; i++){
            var reg = initialState[i];
            regulations[i] = new Regulation(reg.RegId, reg.LegislationSector, reg.Reason, reg.PrivateInformationType, reg.Action, reg.RequiredConsent, true);
        }
        self.regulations = ko.observableArray(regulations);

        self.newRegulation = new EditableRegulation(new Regulation("", "", "", 0, "", 0));
        self.newRegulation.Editing(true);

        self.addReg = function () {
            var newReg = new Regulation(self.newRegulation.RegId(), self.newRegulation.LegislationSector(), self.newRegulation.Reason(), 
                self.newRegulation.PrivateInformationType(), self.newRegulation.Action(), self.newRegulation.RequiredConsent(), true);
            self.regulations.push(newReg);

            self.newRegulation.RegId("");
            self.newRegulation.LegislationSector("");
            self.newRegulation.Reason("");
            self.newRegulation.PrivateInformationType(0);
            self.newRegulation.Action("");
            self.newRegulation.RequiredConsent(0);
        }

        self.removeReg = function (id) {
            var index = self.findReg(id);
            if (index > -1) {
                self.regulations.splice(index, 1);
            }
        }

        self.findReg = function (id) {
            var index = -1;
            for (var i = 0; i < self.regulations().length; i++) {
                if (self.regulations()[i].RegId() === id) {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }

    function addRegulation() {
        $.post({
            url: urlAdd(),
            data: ko.toJSON(regModel.newRegulation),
            contentType: "application/json"
        })
        .done(function (data) {
            regModel.newRegulation.RegId(data);
            regModel.addReg();
            // Just init all the confirmations rather than trying
            // to find the new one specifically
            $('[data-toggle=confirmation]').confirmation({
                rootSelector: '[data-toggle=confirmation]'
            });
        })
        .fail(function(){
            showAlert("The regulation could not be added. Please try again.");
        });
    }

    function updateRegulation(regulation) {
        $.ajax({
            url: urlUpdate(regulation.RegId()),
            method: "PUT",
            contentType: "application/json",
            data: ko.toJSON(regulation.EditableCopy)
        })
        .done(function () {
            // Update the model state with the new values
            regulation.RegId(regulation.EditableCopy.RegId());
            regulation.LegislationSector(regulation.EditableCopy.LegislationSector());
            regulation.Reason(regulation.EditableCopy.Reason());
            regulation.PrivateInformationType(regulation.EditableCopy.PrivateInformationType());
            regulation.Action(regulation.EditableCopy.Action());
            regulation.RequiredConsent(regulation.EditableCopy.RequiredConsent());
            
            regulation.EditableCopy.Editing(false);
        })
        .fail(function(){
            showAlert("The regulation could not be updated. Please try again.");
        });
    }

    function deleteRegulation(){
        var id = $(this).data("id");

        $.ajax({
            url: urlDelete(id),
            method: "DELETE",
        })
        .done(function(data){
            regModel.removeReg(id);
        })
        .fail(function(){
            showAlert("The regulation could not be deleted. Please try again.");
        });
    }

    function showAlert(msg){
        $("#alertModalBody").text(msg);
        $("#alertModal").modal();
    }

    return {
        // Setup with the url generation functions and the initial state
        init: function (_urlAdd, _urlUpdate, _urlDelete, model) {

            urlAdd = _urlAdd;
            urlUpdate = _urlUpdate;
            urlDelete = _urlDelete;

            regModel = new RegulationModel(model);
            this.model = regModel;
            ko.applyBindings(regModel);
        },
        addRegulation: addRegulation,
        updateRegulation: updateRegulation,
        deleteRegulation: deleteRegulation
    };
}();