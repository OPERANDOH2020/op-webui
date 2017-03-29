# I take a official mono image https://hub.docker.com/_/tomcat/
# we choose normal 
FROM tomcat:7-jre8

RUN apt-get update && apt-get install openjdk-8-jdk -y && rm -rf /var/lib/apt/lists/*

ENV MYSQL_DB_USER root
ENV MYSQL_DB_PASSWORD root
ENV MYSQL_DB_NAME operando_data
ENV MYSQL_DB_HOST mysql.integration.operando.lan.esilab.org
ENV RG_BIRT_ENDPOINT http://integration.operando.lan.esilab.org:8120/operando/webui/birt/

ADD generated/. /usr/local/tomcat/webapps

ADD run.sh .
RUN chmod 750 run.sh
ENV PATH /usr/local/tomcat:$PATH

CMD ["run.sh"]