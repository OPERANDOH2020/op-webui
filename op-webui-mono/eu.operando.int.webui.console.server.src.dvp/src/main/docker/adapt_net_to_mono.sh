# I fix the web.config removing codegen
sed -i -e "s/.*<system\.codedom>/<\!--  GBE gives problems in mono xps4 \n  <system\.codedom>/" -e "s/<\/system\.codedom>/<\/system\.codedom>\n-->/" \
/usr/src/app/source/Operando-AdministrationConsole/Web.config 

# esto es para arreglar el problema con el Link dictionary duplicado -> Error building target IncludeRoslynCompilerFilesToItemGroup: Item has already been added. Key in dictionary: 'Link'  Key being added: 'Link'
sed -i -e "s/.*<Import Project=\"\.\.\\\packages\\\Microsoft\.CodeDom\.Providers\.DotNetCompilerPlatform.*>/<\!--\n&\n-->/" \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj
 
sed -i -e "s/.*<Import Project=\"\.\.\\\packages\\\Microsoft\.Net\.Compilers.*>/<\!--\n&\n-->/" \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj

# esto es para arreglar el problema del SharpConnect.MySql
rm -rf /usr/src/app/source/packages/*
xmlstarlet ed --update --inplace  "//_:Reference[contains(@Include,'SharpConnect.MySql')]/@Include" --value "SharpConnect.MySql, Version=1.0.1.0, Culture=neutral, processorArchitecture=MSIL" /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj
sed -e  "s/.*<Reference.*SharpConnect.MySql.*\n(^((?!<Reference).)*\n)*.*<\/Reference>/<Reference Include=\"SharpConnect.MySql, Version=1.0.1.0, Culture=neutral, processorArchitecture=MSIL\">\n  <HintPath>..\\packages\\SharpConnect.MySql.1.0.3\\lib\\netstandard1.6\\SharpConnect.MySql.dll<\/HintPath>\n  <Private>True<\/Private>\n<\/Reference>  /" \
sources/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj
xmlstarlet ed -N x="http://schemas.microsoft.com/developer/msbuild/2003" --update  --inplace  "//x:Reference[contains(@Include,'SharpConnect.MySql')]/x:HintPath" --value "..\\packages\\SharpConnect.MySql.1.0.3\\lib\\netstandard1.6\\SharpConnect.MySql.dll" /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj

# esto es para arreglar el warning del Antlr3.Runtime
xmlstarlet ed -N x="http://schemas.microsoft.com/developer/msbuild/2003" -d --inplace  "//x:Reference[contains(.,'Antlr.3.4.1.9004')]" /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj

# esto es para arreglar el warning del System.Web.Entity 
xmlstarlet ed -N x="http://schemas.microsoft.com/developer/msbuild/2003" -d --inplace  "//x:Reference[contains(@Include,'System.Web.Entity')]" /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj

# esto es para arreglar el warning del Can not evaluate "!$(Disable_CopyWebApplication) And '$(OutDir)' != '$(OutputPath)'" to bool 
sed -e 's/ Condition=.*Disable_CopyWebApplication.*And.*OutDir.*OutputPath.*\"//' \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj

# I fix the missing files issue
head -n -1 \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj \
> /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.tmp \
&& mv /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.tmp \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj

cat \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj.ext \
>> /usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj


# I fix the web.config db
sed -i -e "s/Server=vmxlinux01\.progettidiimpresa\.it/Server=mysql\.integration\.operando\.dmz\.lab\.esilab\.org/" \
/usr/src/app/source/Operando-AdministrationConsole/Web.config 
sed -i -e "s/user id=operando_report/user id=root/" \
/usr/src/app/source/Operando-AdministrationConsole/Web.config 
sed -i -e "s/password=opera22!/password=root/" \
/usr/src/app/source/Operando-AdministrationConsole/Web.config

# Remove the Test project that will not work in mono
sed -i '/^Project.*Operando-AdministrationConsoleTests.*$/{$!{N;s/^Project.*Operando-AdministrationConsoleTests.*\nEndProject//;ty;P;D;:y}}' /usr/src/app/source/Operando-AdministrationConsole.sln 

