#!/bin/bash
cp -r G2C/occ.YellowPages/* op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages

# I fix the web.config removing codegen
sed -i -e "s/.*<system\.codedom>/<\!--  GBE gives problems in mono xps4 \n  <system\.codedom>/" -e "s/<\/system\.codedom>/<\/system\.codedom>\n-->/" \
op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/Web.config 

# esto es para arreglar el problema con el Link dictionary duplicado -> Error building target IncludeRoslynCompilerFilesToItemGroup: Item has already been added. Key in dictionary: 'Link'  Key being added: 'Link'
sed -i -e "s/.*<Import Project=\"\.\.\\\packages\\\Microsoft\.CodeDom\.Providers\.DotNetCompilerPlatform.*>/<\!--\n&\n-->/" \
op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.csproj
 
sed -i -e  "s/.*<Import Project=\"\.\.\\\packages\\\Microsoft\.Net\.Compilers.*>/<\!--\n&\n-->/" \
op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.csproj

# I fix the missing files issue
head -n -1 \
op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.csproj \
> op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.tmp \
&& mv op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.tmp \
op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.csproj

cat \
op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.csproj.ext \
>> op-webui-mono/eu.operando.demo.mono.yellowpages.server/src/main/docker/occ.YellowPages/occ.YellowPages/occ.YellowPages.csproj
