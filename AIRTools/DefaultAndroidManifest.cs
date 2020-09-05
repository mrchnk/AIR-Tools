using System.IO;
using System.Xml;

namespace AIRTools
{
    public static class DefaultAndroidManifest
    {
        public static void Create()
        {
            var androidNS = "http://schemas.android.com/apk/res/android";
            var doc = new XmlDocument();
            var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            var root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            var rootNode = doc.CreateElement("manifest");
            var xmlns = doc.CreateAttribute("xmlns:android");
            xmlns.Value = androidNS;
            rootNode.Attributes.Append(xmlns);
            var xmlnsTools = doc.CreateAttribute("xmlns:tools");
            xmlnsTools.Value = "http://schemas.android.com/tools";
            rootNode.Attributes.Append(xmlnsTools);

            var package = doc.CreateAttribute("package");
            package.Value = "#{applicationId}";
            rootNode.Attributes.Append(package);

            XmlNode usesSdk = doc.CreateElement("uses-sdk");
            var minSdkVersion = doc.CreateAttribute("android", "minSdkVersion", androidNS);
            minSdkVersion.Value = "19";
            usesSdk.Attributes.Append(minSdkVersion);
            var targetSdkVersion = doc.CreateAttribute("android", "targetSdkVersion", androidNS);
            targetSdkVersion.Value = "28";
            usesSdk.Attributes.Append(targetSdkVersion);
            rootNode.AppendChild(usesSdk);

            XmlNode usesPermission = doc.CreateElement("uses-permission");
            var internet = doc.CreateAttribute("android", "name", androidNS);
            internet.Value = "android.permission.INTERNET";
            usesPermission.Attributes.Append(internet);
            rootNode.AppendChild(usesPermission);

            XmlNode application = doc.CreateElement("application");
            var enabled = doc.CreateAttribute("android", "enabled", androidNS);
            enabled.Value = "true";
            application.Attributes.Append(enabled);

            XmlNode metaData = doc.CreateElement("meta-data");
            var aspectRatio = doc.CreateAttribute("android", "name", androidNS);
            aspectRatio.Value = "android.max_aspect";
            metaData.Attributes.Append(aspectRatio);
            var aspectRatioVal = doc.CreateAttribute("android", "value", androidNS);
            aspectRatioVal.Value = "2.1";
            metaData.Attributes.Append(aspectRatioVal);
            application.AppendChild(metaData);

            XmlNode activity = doc.CreateElement("activity");
            var name = doc.CreateAttribute("android", "name", androidNS);
            name.Value = "mainActivity";
            activity.Attributes.Append(name);

            var excludeFromRecents = doc.CreateAttribute("android", "excludeFromRecents", androidNS);
            excludeFromRecents.Value = "false";
            activity.Attributes.Append(excludeFromRecents);

            var hardwareAccelerated = doc.CreateAttribute("android", "hardwareAccelerated", androidNS);
            hardwareAccelerated.Value = "true";
            activity.Attributes.Append(hardwareAccelerated);

            XmlNode intentFilter = doc.CreateElement("intent-filter");

            XmlNode action = doc.CreateElement("action");
            var intentName = doc.CreateAttribute("android", "name", androidNS);
            intentName.Value = "android.intent.action.MAIN";
            action.Attributes.Append(intentName);

            intentFilter.AppendChild(action);

            XmlNode category = doc.CreateElement("category");
            var categoryName = doc.CreateAttribute("android", "name", androidNS);
            categoryName.Value = "android.intent.category.LAUNCHER";
            category.Attributes.Append(categoryName);

            intentFilter.AppendChild(category);

            activity.AppendChild(intentFilter);

            application.AppendChild(activity);

            rootNode.AppendChild(application);
            doc.AppendChild(rootNode);
            doc.Save("tmp/DefaultAndroidManifest.xml");
        }
        
    }
}