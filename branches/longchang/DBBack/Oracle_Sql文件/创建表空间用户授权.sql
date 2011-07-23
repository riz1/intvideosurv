CREATE TEMPORARY TABLESPACE dbo_intvideosurvdb_temp
 TEMPFILE 'E:\oracle\product\10.2.0\oradata\ora\dbo_intvideosurvdb_temp01.dbf ' 
SIZE 32M
 AUTOEXTEND ON 
NEXT 32M MAXSIZE 2048M
 EXTENT MANAGEMENT LOCAL; 
 
 CREATE TABLESPACE dbo_intvideosurvdb_data
 LOGGING
 DATAFILE 'E:\oracle\product\10.2.0\oradata\ora\dbo_intvideosurvdb_DATA01.DBF ' 
SIZE 32M 
AUTOEXTEND ON 
NEXT 32M MAXSIZE 2048M
 EXTENT MANAGEMENT LOCAL; 
 
 CREATE USER dbo_intvideosurvdb IDENTIFIED BY dbo_intvideosurvdb
 DEFAULT TABLESPACE dbo_intvideosurvdb_data
 TEMPORARY TABLESPACE dbo_intvideosurvdb_temp;
 
 GRANT 
　　 CREATE SESSION, CREATE ANY TABLE , CREATE ANY VIEW , CREATE ANY INDEX , CREATE ANY PROCEDURE ,
 　　 ALTER ANY TABLE , ALTER ANY PROCEDURE ,
 　　 DROP ANY TABLE , DROP ANY VIEW , DROP ANY INDEX , DROP ANY PROCEDURE ,
 　　 SELECT ANY TABLE , INSERT ANY TABLE , UPDATE ANY TABLE , DELETE ANY TABLE 
　　 TO dbo_intvideosurvdb; 
Grant 
		AQ_ADMINISTRATOR_ROLE,CONNET,Resource to dbo_intvideosurvdb;
 
