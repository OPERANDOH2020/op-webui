using System.Collections.Generic;
using System.Linq;
using eu.operando.core.pdb.cli.Model;

namespace Operando_AdministrationConsole.Models.DataSubjectModels
{
    public class AccessPreferenceModel
    {
        public bool selected { get; set; }
        public string OspId { get; set; }
        public IList<GroupedPolicyModel> map { get; set; }

        public AccessPreferenceModel(ModOSPConsents entity)
        {
            selected = entity.selected;
            OspId = entity.OspId;
            map = entity.map.Select(g => new GroupedPolicyModel(g)).ToList();
        }

    }

    public class GroupedPolicyModel
    {
        public List<AccessPolicyModel> gap { get; set; }
        public string groupKey { get; set; }

        public GroupedPolicyModel(GroupAccessPolicies entity)
        {
            gap = entity.gap.Select(ap => new AccessPolicyModel(ap)).ToList();
            groupKey = entity.groupKey;
        }
    }

    public class AccessPolicyModel
    {
        public string Subject { get; set; }
        public string Resource { get; set; }
        public bool? Permission { get; set; }
        public List<AttributeModel> Attributes { get; set; }
        public AccessPolicy.ActionEnum? Action { get; set; }

        public AccessPolicyModel(AccessPolicy ap)
        {
            Action = ap.Action;
            Attributes = ap.Attributes.Select(a => new AttributeModel(a)).ToList();
            Permission = ap.Permission;
            Resource = ap.Resource;
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
