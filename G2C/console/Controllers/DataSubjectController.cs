using System.Collections.Generic;
using System.Web.Mvc;
using Operando_AdministrationConsole.Models;
using eu.operando.core.pdb.cli.Model;
using Operando_AdministrationConsole.Helper;
using AccessPolicy = eu.operando.core.pdb.cli.Model.AccessPolicy;

namespace Operando_AdministrationConsole.Controllers
{

    public class DataSubjectController : Controller
    {

        public ActionResult DataAccessLogs()
        {
            List<DataAccessLog> logList = new List<DataAccessLog>();

            List<DataAccessLog> stubLogs = AmiRandoStubHelper.GetStubAccessLogs();
            logList.AddRange(stubLogs);

            return View(logList);
        }

        public ActionResult AccessPreferences()
        {
            ViewBag.ospppList = AmiRandoStubHelper.GetAmiUserPrivacyPolicy();
            return View();
        }

        [HttpPost]
        public ActionResult AccessPreferences(FormCollection formCollectionAccessPreferences)
        {
            // Interepret the form collection.
            List<string> hashCodePairStringList = generateHashCodePairStringList(formCollectionAccessPreferences);
            Dictionary<string, List<string>> dictionaryHashCodesUserTypeToDataTypes = CreateDictionaryFromHashCodePairStrings(hashCodePairStringList);

            // Inform the stub helper of the incoming access preferences.
            AmiRandoStubHelper.UpdateAmiUserPrivacyPolicy(dictionaryHashCodesUserTypeToDataTypes);

            // Use the new access preferences on the screen.
            ViewBag.ospppList = AmiRandoStubHelper.GetAmiUserPrivacyPolicy();
            return View();
        }

        private static Dictionary<string, List<string>> CreateDictionaryFromHashCodePairStrings(List<string> hashCodePairStringList)
        {
            Dictionary<string, List<string>> dictionaryHashCodesUserTypeToDataTypes = new Dictionary<string, List<string>>();

            foreach (string strAccessPreferenceHashCodePair in hashCodePairStringList)
            {
                string[] accessPreferenceHashCodePair = strAccessPreferenceHashCodePair.Split(' ');
                string hashcodeUserType = accessPreferenceHashCodePair[0];
                string hashcodeDataType = accessPreferenceHashCodePair[1];

                if (!dictionaryHashCodesUserTypeToDataTypes.ContainsKey(hashcodeUserType))
                {
                    List<string> hashcodesDataTypes = new List<string>();
                    hashcodesDataTypes.Add(hashcodeDataType);
                    dictionaryHashCodesUserTypeToDataTypes.Add(hashcodeUserType, hashcodesDataTypes);
                }
                else
                {
                    dictionaryHashCodesUserTypeToDataTypes[hashcodeUserType].Add(hashcodeDataType);
                }
            }
            return dictionaryHashCodesUserTypeToDataTypes;
        }

        private static List<string> generateHashCodePairStringList(FormCollection formCollectionAccessPreferences)
        {
            List<string> accessPreferenceHashCodePairs = new List<string>();
            foreach (string key in formCollectionAccessPreferences.AllKeys)
            {
                accessPreferenceHashCodePairs.Add(key);
            }
            // The last key that is posted is the policy URL. Pretty horrible I know, but not worth investigating an alternative at the moment.
            accessPreferenceHashCodePairs.RemoveAt(accessPreferenceHashCodePairs.Count - 1);
            return accessPreferenceHashCodePairs;
        }

        public ActionResult PrivacyWizard()
        {
            return View();
        }


    }
}