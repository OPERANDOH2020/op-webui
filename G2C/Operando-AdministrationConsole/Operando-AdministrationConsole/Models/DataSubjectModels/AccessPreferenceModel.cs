using System.Collections.Generic;
using System.Linq;
using eu.operando.core.pdb.cli.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{

    public class AccessPreferenceModel
    {
        public bool Selected { get; set; }
        public string OspId { get; set; }
        public IList<GroupedPolicyModel> Map { get; set; }

        public AccessPreferenceModel(ModOSPConsents entity)
        {
            Selected = entity.selected;
            OspId = entity.OspId;
            Map = entity.map.Select(g => new GroupedPolicyModel(g)).ToList();
        }

    }

    public class GroupedPolicyModel
    {
        private static readonly Dictionary<string, string> AccessorDictionary = new Dictionary<string, string>
        {
            {"volunteer_linkup", "Volunteer Linkup"},
            {"abingdon_good_neighbour_scheme", "Abingdon Good Neighbour Scheme"}
        };

        public List<AccessPolicyModel> GroupedPolicies { get; set; }

        public string GroupKey => AccessorDictionary.ContainsKey(RawGroupKey) ? AccessorDictionary[RawGroupKey] : RawGroupKey;

        private string RawGroupKey { get; set; }

        public GroupedPolicyModel(GroupAccessPolicies entity)
        {
            GroupedPolicies = entity.gap.Select(ap => new AccessPolicyModel(ap)).ToList();
            RawGroupKey = entity.groupKey;
        }
    }

    public class AccessPolicyModel
    {
        public static readonly Dictionary<string, string> ResourceDictionary = new Dictionary<string, string>
        {
            // TODO if we're changing these
        };

        public string Subject { get; set; }
        public string RawResource { get; set; }
        public bool? Permission { get; set; }
        public List<AttributeModel> Attributes { get; set; }
        public AccessPolicy.ActionEnum? Action { get; set; }

        public string Resource => ResourceDictionary.ContainsKey(RawResource) ? ResourceDictionary[RawResource] : RawResource;

        public AccessPolicyModel(AccessPolicy ap)
        {
            Action = ap.Action;
            Attributes = ap.Attributes.Select(a => new AttributeModel(a)).ToList();
            Permission = ap.Permission;
            RawResource = ap.Resource;
            Subject = ap.Subject;
        }
    }

    public class AttributeModel
    {
        public string AttributeValue { get; set; }
        public string AttributeName { get; set; }

        public AttributeModel(PolicyAttribute a)
        {
            AttributeName = a.AttributeName;
            AttributeValue = a.AttributeValue;
        }
    }
}
