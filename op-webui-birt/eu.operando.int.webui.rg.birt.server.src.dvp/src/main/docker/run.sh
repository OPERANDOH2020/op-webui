#!/bin/bash
#!/bin/bash

echo MYSQL_DB_HOST: $MYSQL_DB_HOST
echo MYSQL_DB_NAME: $MYSQL_DB_NAME
echo MYSQL_DB_USER: $MYSQL_DB_USER
echo MYSQL_DB_PASSWORD: $MYSQL_DB_PASSWORD

MYSQL_DB_PASSWORD_ENCRYPTED=`echo -n "$MYSQL_DB_PASSWORD" | base64`
echo MYSQL_DB_PASSWORD_ENCRYPTED: $MYSQL_DB_PASSWORD_ENCRYPTED

WAR_FILENAME=operando#webui#birt
WAR_FILE=$WAR_FILENAME.war
WAR_DIR=/usr/local/tomcat/webapps
TMP_DIR=/tmp
echo War Filename: $WAR_FILENAME
echo War File: $WAR_FILE
echo War Directory: $WAR_DIR
echo Tmp Dir: $TMP_DIR

echo Decompress file to tmp
mkdir -p $TMP_DIR/$WAR_FILENAME
cd $TMP_DIR/$WAR_FILENAME
jar xvf $WAR_DIR/$WAR_FILE 


echo Replace 
grep -rl -e "jdbc:.*:3306\/[^\?]*" --include="*.rptdesign" | xargs sed -i -e "s/jdbc:.*:3306\/[^\?]*/jdbc:mysql:\/\/$MYSQL_DB_HOST:3306\/$MYSQL_DB_NAME/g"
grep -rl -e "<.*\"odaUser\">.*<\/property>" --include="*.rptdesign" | xargs sed -i -e "s/\(<.*\"odaUser\">\)\(.*\)\(<\/property>\)/\1$MYSQL_DB_USER\3/g" 
grep -rl -e "<.*\"odaPassword\".*>.*<\/encrypted-property>" --include="*.rptdesign" | xargs sed -i -e "s/\(<.*\"odaPassword\".*>\)\(.*\)\(<\/encrypted-property>\)/\1$MYSQL_DB_PASSWORD_ENCRYPTED\3/g" 

echo Recompress file
jar cvf $WAR_FILE .

echo move file
mv $TMP_DIR/$WAR_FILENAME/$WAR_FILE $WAR_DIR/$WAR_FILE

catalina.sh run
