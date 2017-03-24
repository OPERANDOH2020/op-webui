# I take a official mono image https://hub.docker.com/_/tomcat/
# we choose normal 
FROM tomcat:7-jre8

ADD generated/. /usr/local/tomcat/webapps

ADD run.sh .
RUN chmod 750 run.sh
ENV PATH /usr/local/tomcat:$PATH

CMD ["run.sh"]