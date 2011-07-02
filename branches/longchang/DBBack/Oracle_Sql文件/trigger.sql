--------------------------------------------------------
--  文件已创建 - 星期六-七月-02-2011   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Trigger ALARM
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."ALARM" 
  after insert on tog_vehmon  
  for each row

  
begin
  INSERT INTO tog_vehdispalarm (mvid, clxxbh, kkbh, kkmc, fxbh, fxmc, cdbh, cdmc, jgsk, hphm, hpysbh, hpys, 
  txsl, txmc1,txmc2, txmc3, txmc4, spmc, clsd, xszt, clpp, clwx, csys, clwkc, cllx, cllxmc, hpzl, hpzlmc, ylxxlx, ylxx, sbzt,dwbh, dwmc, bz, 
  bjxxbh, bkxxbh, bjsj) 
  select :new.mvid, :new.clxxbh, :new.kkbh, :new.kkmc, :new.fxbh, :new.fxmc, :new.cdbh, :new.cdmc, :new.jgsk, :new.hphm, :new.hpysbh, :new.hpys, 
  :new.txsl, :new.txmc1,:new.txmc2, :new.txmc3, :new.txmc4, :new.spmc, :new.clsd, :new.xszt, :new.clpp, :new.clwx, :new.csys, :new.clwkc, :new.cllx, :new.cllxmc, :new.hpzl, :new.hpzlmc, :new.ylxxlx, :new.ylxx, :new.sbzt, :new.dwbh, :new.dwmc, :new.bz, 
  bjxxbh_seq.nextval, bkxxbh, sysdate
  from tog_vehdisp where shzt='1' and ckshzt!='1' and hphm=:new.hphm;
end;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."ALARM" ENABLE;
--------------------------------------------------------
--  DDL for Trigger CAMERAGROUP_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."CAMERAGROUP_TRG" BEFORE INSERT ON IVS_CAMERAGROUP 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF :NEW.ID IS NULL THEN
      SELECT CAMERAGROUP_SEQ.NEXTVAL INTO :NEW.ID FROM DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."CAMERAGROUP_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger CAMERAINFO_CAMERAID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."CAMERAINFO_CAMERAID_TRG" BEFORE INSERT OR UPDATE ON IVS_CAMERAINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.CameraId IS NULL THEN
    SELECT  CameraInfo_CameraId_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(CameraId),0) INTO v_newVal FROM IVS_CameraInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT CameraInfo_CameraId_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.CameraId := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."CAMERAINFO_CAMERAID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger CAPTUREPICTURE_PICTUREID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."CAPTUREPICTURE_PICTUREID_TRG" BEFORE INSERT OR UPDATE ON IVS_CAPTUREPICTURE
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.PictureID IS NULL THEN
    SELECT  CapturePicture_PictureID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(PictureID),0) INTO v_newVal FROM IVS_CapturePicture;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT CapturePicture_PictureID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.PictureID := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."CAPTUREPICTURE_PICTUREID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger DECODERCAMERA_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."DECODERCAMERA_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_DECODERCAMERA
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.id IS NULL THEN
    SELECT  DecoderCamera_id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(id),0) INTO v_newVal FROM IVS_DecoderCamera;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT DecoderCamera_id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."DECODERCAMERA_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger DECODERINFO_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."DECODERINFO_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_DECODERINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.id IS NULL THEN
    SELECT  DecoderInfo_id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(id),0) INTO v_newVal FROM IVS_DecoderInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT DecoderInfo_id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."DECODERINFO_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger DEFAULTCARDOUT_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."DEFAULTCARDOUT_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_DEFAULTCARDOUT
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  DefaultCardOut_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_DefaultCardOut;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT DefaultCardOut_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."DEFAULTCARDOUT_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger EVENTINFO_EVENTID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."EVENTINFO_EVENTID_TRG" BEFORE INSERT OR UPDATE ON IVS_EVENTINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.EventId IS NULL THEN
    SELECT  EventInfo_EventId_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(EventId),0) INTO v_newVal FROM IVS_EventInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT EventInfo_EventId_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.EventId := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."EVENTINFO_EVENTID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger EVENTRECTINFO_EVENTRECTID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."EVENTRECTINFO_EVENTRECTID_TRG" BEFORE INSERT OR UPDATE ON IVS_EVENTRECTINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.EventRectId IS NULL THEN
    SELECT  EventRectInfo_EventRectId_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(EventRectId),0) INTO v_newVal FROM IVS_EventRectInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT EventRectInfo_EventRectId_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.EventRectId := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."EVENTRECTINFO_EVENTRECTID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger FACE_FACEID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."FACE_FACEID_TRG" BEFORE INSERT OR UPDATE ON IVS_FACE
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.FaceID IS NULL THEN
    SELECT  Face_FaceID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(FaceID),0) INTO v_newVal FROM IVS_Face;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT Face_FaceID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.FaceID := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."FACE_FACEID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger GROUPINFO_GROUPID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."GROUPINFO_GROUPID_TRG" BEFORE INSERT OR UPDATE ON IVS_GROUPINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.GroupID IS NULL THEN
    SELECT  GroupInfo_GroupID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(GroupID),0) INTO v_newVal FROM IVS_GroupInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT GroupInfo_GroupID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.GroupID := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."GROUPINFO_GROUPID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger GROUPSWITCHDETAIL_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."GROUPSWITCHDETAIL_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_GROUPSWITCHDETAIL
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  GroupSwitchDetail_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_GroupSwitchDetail;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT GroupSwitchDetail_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."GROUPSWITCHDETAIL_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger GROUPSWITCHGROUP_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."GROUPSWITCHGROUP_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_GROUPSWITCHGROUP
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  GroupSwitchGroup_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_GroupSwitchGroup;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT GroupSwitchGroup_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."GROUPSWITCHGROUP_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger INSERT_ACCESSLOG_ID
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_ACCESSLOG_ID" 
BEFORE INSERT ON ACCESSLOG
REFERENCING NEW AS new OLD AS old
FOR EACH ROW
BEGIN
    SELECT ACCESSLOG_ID_SEQ.NEXTVAL INTO :new.id FROM DUAL;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_ACCESSLOG_ID" ENABLE;
--------------------------------------------------------
--  DDL for Trigger INSERT_FI_FLOW_FIID
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_FI_FLOW_FIID" 
BEFORE INSERT ON FI_FLOW
REFERENCING NEW AS new OLD AS old
FOR EACH ROW
BEGIN
    SELECT FI_FLOW_FIID_SEQ.NEXTVAL INTO :new.fiid FROM DUAL;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_FI_FLOW_FIID" ENABLE;
--------------------------------------------------------
--  DDL for Trigger INSERT_FI_TASK_PREV_ID
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_FI_TASK_PREV_ID" 
BEFORE INSERT ON FI_TASK_PREV
REFERENCING NEW AS new OLD AS old
FOR EACH ROW
BEGIN
    SELECT FI_TASK_PREV_ID_SEQ.NEXTVAL INTO :new.id FROM DUAL;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_FI_TASK_PREV_ID" ENABLE;
--------------------------------------------------------
--  DDL for Trigger INSERT_FI_TASK_TIID
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_FI_TASK_TIID" 
BEFORE INSERT ON FI_TASK
REFERENCING NEW AS new OLD AS old
FOR EACH ROW
BEGIN
    SELECT FI_TASK_TIID_SEQ.NEXTVAL INTO :new.tiid FROM DUAL;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."INSERT_FI_TASK_TIID" ENABLE;
--------------------------------------------------------
--  DDL for Trigger MAPINFO_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."MAPINFO_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_MAPINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.id IS NULL THEN
    SELECT  MapInfo_id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(id),0) INTO v_newVal FROM IVS_MapInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT MapInfo_id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."MAPINFO_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger OBJECTINFO_OBJECTID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."OBJECTINFO_OBJECTID_TRG" BEFORE INSERT OR UPDATE ON IVS_OBJECTINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.ObjectId IS NULL THEN
    SELECT  ObjectInfo_ObjectId_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(ObjectId),0) INTO v_newVal FROM IVS_ObjectInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT ObjectInfo_ObjectId_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.ObjectId := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."OBJECTINFO_OBJECTID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger OPERATELOG_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."OPERATELOG_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_OPERATELOG
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  OperateLog_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_OperateLog;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT OperateLog_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."OPERATELOG_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PROGSWITCH_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."PROGSWITCH_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_PROGSWITCH
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  ProgSwitch_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_ProgSwitch;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT ProgSwitch_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."PROGSWITCH_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger PROGSWITCHDETAIL_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."PROGSWITCHDETAIL_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_PROGSWITCHDETAIL
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  ProgSwitchDetail_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_ProgSwitchDetail;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT ProgSwitchDetail_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."PROGSWITCHDETAIL_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger RECOGNIZERCAMERA_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."RECOGNIZERCAMERA_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_RECOGNIZERCAMERA
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  RecognizerCamera_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_RecognizerCamera;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT RecognizerCamera_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."RECOGNIZERCAMERA_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger RECOGNIZERINFO_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."RECOGNIZERINFO_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_RECOGNIZERINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  RecognizerInfo_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_RecognizerInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT RecognizerInfo_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."RECOGNIZERINFO_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger RECT_RECTID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."RECT_RECTID_TRG" BEFORE INSERT OR UPDATE ON IVS_RECT
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.RectID IS NULL THEN
    SELECT  REct_RectID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(RectID),0) INTO v_newVal FROM IVS_REct;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT REct_RectID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.RectID := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."RECT_RECTID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger SYNCAMERA_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."SYNCAMERA_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_SYNCAMERA
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  SynCamera_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_SynCamera;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT SynCamera_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."SYNCAMERA_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger SYNGROUP_SYNGROUPID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."SYNGROUP_SYNGROUPID_TRG" BEFORE INSERT OR UPDATE ON IVS_SYNGROUP
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.SynGroupId IS NULL THEN
    SELECT  SynGroup_SynGroupId_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(SynGroupId),0) INTO v_newVal FROM IVS_SynGroup;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT SynGroup_SynGroupId_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.SynGroupId := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."SYNGROUP_SYNGROUPID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger SYSTEMLOG_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."SYSTEMLOG_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_SYSTEMLOG
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.id IS NULL THEN
    SELECT  SystemLog_id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(id),0) INTO v_newVal FROM IVS_SystemLog;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT SystemLog_id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."SYSTEMLOG_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TEMPPICTURE_PICTUREID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."TEMPPICTURE_PICTUREID_TRG" BEFORE INSERT OR UPDATE ON IVS_TEMPPICTURE
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.PictureID IS NULL THEN
    SELECT  TempPicture_PictureID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(PictureID),0) INTO v_newVal FROM IVS_TempPicture;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT TempPicture_PictureID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.PictureID := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."TEMPPICTURE_PICTUREID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRACK_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."TRACK_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_TRACK
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.Id IS NULL THEN
    SELECT  Track_Id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(Id),0) INTO v_newVal FROM IVS_Track;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT Track_Id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.Id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."TRACK_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger USERGROUP_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."USERGROUP_TRG" BEFORE INSERT ON IVS_USERGROUP 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF :NEW.ID IS NULL THEN
      SELECT USERGROUP_SEQ.NEXTVAL INTO :NEW.ID FROM DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."USERGROUP_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger USERINFO_USERID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."USERINFO_USERID_TRG" BEFORE INSERT OR UPDATE ON IVS_USERINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.userid IS NULL THEN
    SELECT  UserInfo_userid_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(userid),0) INTO v_newVal FROM IVS_UserInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT UserInfo_userid_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.userid := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."USERINFO_USERID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger VIDEOINFO_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."VIDEOINFO_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_VIDEOINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.ID IS NULL THEN
    SELECT  VideoInfo_ID_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(ID),0) INTO v_newVal FROM IVS_VideoInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT VideoInfo_ID_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.ID := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."VIDEOINFO_ID_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger VIRTUALGROUP_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."VIRTUALGROUP_TRG" BEFORE INSERT ON IVS_VIRTUALGROUP 
FOR EACH ROW 
BEGIN
  <<COLUMN_SEQUENCES>>
  BEGIN
    IF :NEW.ID IS NULL THEN
      SELECT VIRTUALGROUP_SEQ.NEXTVAL INTO :NEW.ID FROM DUAL;
    END IF;
  END COLUMN_SEQUENCES;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."VIRTUALGROUP_TRG" ENABLE;
--------------------------------------------------------
--  DDL for Trigger WINDOWCAMERAINFO_ID_TRG
--------------------------------------------------------

  CREATE OR REPLACE TRIGGER "DBO_INTVIDEOSURVDB"."WINDOWCAMERAINFO_ID_TRG" BEFORE INSERT OR UPDATE ON IVS_WINDOWCAMERAINFO
FOR EACH ROW
DECLARE 
v_newVal NUMBER(12) := 0;
v_incval NUMBER(12) := 0;
BEGIN
  IF INSERTING AND :new.id IS NULL THEN
    SELECT  WindowCameraInfo_id_SEQ.NEXTVAL INTO v_newVal FROM DUAL;
    -- If this is the first time this table have been inserted into (sequence == 1)
    IF v_newVal = 1 THEN 
      --get the max indentity value from the table
      SELECT NVL(max(id),0) INTO v_newVal FROM IVS_WindowCameraInfo;
      v_newVal := v_newVal + 1;
      --set the sequence to that value
      LOOP
           EXIT WHEN v_incval>=v_newVal;
           SELECT WindowCameraInfo_id_SEQ.nextval INTO v_incval FROM dual;
      END LOOP;
    END IF;
    -- save this to emulate @@identity
   sqlserver_utilities.identity := v_newVal; 
   -- assign the value from the sequence to emulate the identity column
   :new.id := v_newVal;
  END IF;
END;

/
ALTER TRIGGER "DBO_INTVIDEOSURVDB"."WINDOWCAMERAINFO_ID_TRG" ENABLE;
