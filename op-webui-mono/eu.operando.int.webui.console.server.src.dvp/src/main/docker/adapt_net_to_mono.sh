# I fix the web.config removing codegen
sed -i -e "s/.*<system\.codedom>/<\!--  GBE gives problems in mono xps4 \n  <system\.codedom>/" -e "s/<\/system\.codedom>/<\/system\.codedom>\n-->/" \
/usr/src/app/source/Operando-AdministrationConsole/Web.config 

# esto es para arreglar el problema con el Link dictionary duplicado -> Error building target IncludeRoslynCompilerFilesToItemGroup: Item has already been added. Key in dictionary: 'Link'  Key being added: 'Link'
sed -i -e "s/.*<Import Project=\"\.\.\\\packages\\\Microsoft\.CodeDom\.Providers\.DotNetCompilerPlatform.*>/<\!--\n&\n-->/" \
/usr/src/app/source/Operando-AdministrationConsole/Operando-AdministrationConsole.csproj
 
sed -i -e  "s/.*<Import Project=\"\.\.\\\packages\\\Microsoft\.Net\.Compilers.*>/<\!--\n&\n-->/" \
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

