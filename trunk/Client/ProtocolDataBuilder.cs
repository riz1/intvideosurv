using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraViewer
{
    public class ProtocolDataBuilder
    {
        public ProtocolDataItem SelectMatrix(byte byMonitorNum, byte byMatrixNetNum)
        {
            /*#########运行时日志 2010-03-11新增###########*/
            //RunLog("SelectMatrix())", "MatrixProtocolBuilder.cpp");
            /*#############################################*/

            //选择网络主机
            //数据：F4 00  20  MON  NET  00  CH   00
            //MON:监视器号(01-0x80)    NET:网络号(00-0x20)

            ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
            protocolDataItem.Data[0] = 0xF4;
            protocolDataItem.Data[1] = 0;
            protocolDataItem.Data[2] = 0x20;
            protocolDataItem.Data[3] = byMonitorNum;
            protocolDataItem.Data[4] = byMatrixNetNum;
            protocolDataItem.Data[5] = 0;
            protocolDataItem.Data[7] = 0;
            protocolDataItem.Data[6] = (byte)(0x20 + byMonitorNum + byMatrixNetNum);
            //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
            //protocolDataItem.Data[6] = protocolDataItem.Data[1]+protocolDataItem.Data[2]+protocolDataItem.Data[3]+protocolDataItem.Data[4]+protocolDataItem.Data[5]+protocolDataItem.Data[7];

            return protocolDataItem;
        }

        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : SelectCamera
        功能     : (选择摄像机) 创建一条矩阵控制协议数据，用于选择使用主控矩阵上的摄像机!!!
		           (注：该函数在效率上比返回值为ProtocolDataSet的SelectCamera重载函数要高，但
		           只能用于选择使用主控矩阵上的摄像机的情况!!!)

        参数     : [IN] byFinalMonitorNum : 监视器号(直接与视频服务器相连接的监视器号)(01-0x80)
		           [IN] byMatrixNetNum :	与摄像机所连接矩阵的网络号
		           [IN] nCameraNum :		摄像机在矩阵上的视频输入端口号（01H-400H）
        		   
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem SelectCamera(byte byFinalMonitorNum, byte byMatrixNetNum, int nCameraNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("MatrixProtocolBuilder::SelectCamera())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

            ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
            
            

	        //选择摄像机号为“nCameraNum”的摄像机
	        //数据：F4 CAML  21  MON  NET 00  CH   CAMH
	        //MON:监视器号(01-0x80)     NET:网络号(00-0x20)   CAM：摄像机号
	        //CAML：摄像机号低8位     CAMH：摄像机号高8位
	        protocolDataItem.Data[0] = 0xF4;
	        protocolDataItem.Data[1] = (byte)(nCameraNum);//CAML：摄像机号低8位
	        protocolDataItem.Data[2] = 0x21;
	        protocolDataItem.Data[3] = byFinalMonitorNum;//MON
	        protocolDataItem.Data[4] = byMatrixNetNum;//NET
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(nCameraNum>>8);//CAMH：摄像机号高8位
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1]) + 0x21
		        + byFinalMonitorNum + byMatrixNetNum + (byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        //////////////////////////////////////////////////////////////////////////////////////
        //云台转动协议：
        //////////////////////////////////////////////////////////////////////////////////////


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltUp
        功能     : (云台向上动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向上动作。
        参数     : [IN] decoderNum :	 云台的解码器号（01-0x400）
		           [IN] bySpeed_UpDown : 云台上下速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltUp(int decoderNum, byte bySpeed_UpDown)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltUp())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //云台向上动作 
	        //数据：F2  IDL  01  SUD  00  00  CH  IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位
	        //IDH：解码器高8位
	        //SUD:云台上下速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x01;
	        protocolDataItem.Data[3] = bySpeed_UpDown;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1]) + 0x01 + bySpeed_UpDown + (byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltDown
        功能     : (云台向下动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向下动作。
        参数     : [IN] decoderNum :	 云台的解码器号（01-0x400）
		           [IN] bySpeed_UpDown : 云台上下速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltDown(int decoderNum, byte bySpeed_UpDown)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltDown())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //云台向下动作 
	        //数据：F2  IDL  02  SUD  00  00  CH  IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SUD:云台上下速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x02;
	        protocolDataItem.Data[3] = bySpeed_UpDown;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1]) + 0x02 + bySpeed_UpDown + (byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltLeft
        功能     : (云台向左动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向左动作。
        参数     : [IN] decoderNum :		云台的解码器号（01-0x400）
		           [IN] bySpeed_LeftRight : 云台上下速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltLeft(int decoderNum, byte bySpeed_LeftRight)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltLeft())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //云台向左动作 
	        //数据：F2  IDL  04  00  SLR  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SLR:云台左右速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x04;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = bySpeed_LeftRight;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x04+bySpeed_LeftRight+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltRight
        功能     : (云台向右动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向右动作。
        参数     : [IN] decoderNum :		云台的解码器号（01-0x400）
		           [IN] bySpeed_LeftRight : 云台上下速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltRight(int decoderNum, byte bySpeed_LeftRight)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltRight())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //云台向右动作 
	        //数据：F2  IDL  08  00  SLR  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SLR:云台左右速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x08;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = bySpeed_LeftRight;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x08+bySpeed_LeftRight+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltLeftUp
        功能     : (云台向左上动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向左上动作。
        参数     : [IN] decoderNum :		云台的解码器号（01-0x400）
		           [IN] bySpeed_UpDown :	云台上下速度值（00-0x3F）
		           [IN] bySpeed_LeftRight : 云台左右速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltLeftUp(int decoderNum, byte bySpeed_UpDown, byte bySpeed_LeftRight)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltLeftUp())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        // 5、云台向左上动作
	        //数据：F2  IDL  05  SUD  SLR  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SUD:云台上下速度值（00-0x3F）
	        //SLR:云台左右速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x05;
	        protocolDataItem.Data[3] = bySpeed_UpDown;
	        protocolDataItem.Data[4] = bySpeed_LeftRight;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x05+bySpeed_UpDown+bySpeed_LeftRight+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltLeftDown
        功能     : (云台向左下动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向左下动作。
        参数     : [IN] decoderNum :		云台的解码器号（01-0x400）
		           [IN] bySpeed_UpDown :	云台上下速度值（00-0x3F）
		           [IN] bySpeed_LeftRight : 云台左右速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltLeftDown(int decoderNum, byte bySpeed_UpDown, byte bySpeed_LeftRight)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltLeftDown())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //6、云台向左下动作
	        //数据：F2  IDL  06  SUD  SLR  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SUD:云台上下速度值（00-0x3F）
	        //SLR:云台左右速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x06;
	        protocolDataItem.Data[3] = bySpeed_UpDown;
	        protocolDataItem.Data[4] = bySpeed_LeftRight;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x06+bySpeed_UpDown+bySpeed_LeftRight+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltRightUp
        功能     : (云台向右上动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向右上动作。
        参数     : [IN] decoderNum :		云台的解码器号（01-0x400）
		           [IN] bySpeed_UpDown :	云台上下速度值（00-0x3F）
		           [IN] bySpeed_LeftRight : 云台左右速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltRightUp(int decoderNum, byte bySpeed_UpDown, byte bySpeed_LeftRight)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltRightUp())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //7、云台向右上动作 
	        //数据：F2  IDL  09  SUD  SLR  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SUD:云台上下速度值（00-0x3F）
	        //SLR:云台左右速度值（00-0x3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x09;
	        protocolDataItem.Data[3] = bySpeed_UpDown;
	        protocolDataItem.Data[4] = bySpeed_LeftRight;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x09+bySpeed_UpDown+bySpeed_LeftRight+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_TiltRightDown
        功能     : (云台向右下动作) 创建一条矩阵控制协议数据，用于控制摄像机的云台向右下动作。
        参数     : [IN] decoderNum :		云台的解码器号（01-0x400）
		           [IN] bySpeed_UpDown :	云台上下速度值（00-0x3F）
		           [IN] bySpeed_LeftRight : 云台左右速度值（00-0x3F）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_TiltRightDown(int decoderNum, byte bySpeed_UpDown, byte bySpeed_LeftRight)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_TiltRightDown())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //8、云台向右下动作 
	        //数据：F2  IDL  0A SUD  SLR  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //SUD:云台上下速度值（00-3F）
	        //SLR:云台左右速度值（00-3F）

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x0A;
	        protocolDataItem.Data[3] = bySpeed_UpDown;
	        protocolDataItem.Data[4] = bySpeed_LeftRight;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x0A+bySpeed_UpDown+bySpeed_LeftRight+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }



        //////////////////////////////////////////////////////////////////////////////////////
        //镜头变换动作：
        ////////////////////////////////////////////////////////////////////////////////////// 


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Iris_Enlarge
        功能     : (镜头光圈扩大动作)  创建一条矩阵控制协议数据，用于控制摄像机的镜头光圈扩大动作。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Iris_Enlarge(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Iris_Enlarge())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //1、镜头光圈(IRIS)+动作 
	        //数据：F2  IDL  0B  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x0B;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x0B+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Iris_Shrink
        功能     : (镜头光圈缩小动作)  创建一条矩阵控制协议数据，用于控制摄像机的镜头光圈缩小动作。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Iris_Shrink(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Iris_Shrink())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //2、镜头光圈(IRIS)-动作 
	        //数据：F2  IDL  0C  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x0C;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x0C+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Focus_Out
        功能     : (镜头焦点后调动作（镜头聚焦+）)  创建一条矩阵控制协议数据，用于控制摄像机的镜头焦点后调动作（镜头聚焦+）。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Focus_Out(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Focus_Out())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //3、镜头聚焦(FOCUS)+动作 
	        //数据：数据：F2  IDL  0D  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x0D;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x0D+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Focus_In
        功能     : (镜头焦点前调动作（镜头聚焦-）)  创建一条矩阵控制协议数据，用于控制摄像机的镜头焦点前调动作（镜头聚焦-）。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Focus_In(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Focus_In())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //4、镜头聚焦(FOCUS)-动作 
	        //数据：数据：F2  IDL  0E  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x0E;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x0E+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Zoom_In
        功能     : (镜头焦距变小(倍率变小)动作  即缩小)  创建一条矩阵控制协议数据，用于控制摄像机的镜头焦距变小(倍率变小)动作  即缩小。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Zoom_In(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Zoom_In())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //5、镜头变倍(ZOOM)+动作 
	        //数据：F2  IDL  0F  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x0F;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x0F+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Zoom_Out
        功能     : (镜头焦距变大(倍率变大)动作  即放大)  创建一条矩阵控制协议数据，用于控制摄像机的镜头焦距变大(倍率变大)动作  即放大。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Zoom_Out(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Zoom_Out())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //6、镜头变倍(ZOOM)-动作 
	        //数据：F2  IDL  10  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x10;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x10+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }



        //////////////////////////////////////////////////////////////////////////////////////
        //云台/镜头动作停：
        ////////////////////////////////////////////////////////////////////////////////////// 


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Stop_PTZControl
        功能     : (云台动作停)  创建一条矩阵控制协议数据，用于控制摄像机的云台动作停。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Stop_PTZControl(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Stop_PTZControl())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //1、云台动作停 
	        //数据：F2  IDL  03  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x03;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x03+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Stop_LensControl
        功能     : (镜头动作停)  创建一条矩阵控制协议数据，用于控制摄像机的镜头动作停。
        参数     : [IN] decoderNum :  解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Stop_LensControl(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Stop_LensControl())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //2、镜头动作停 
	        //数据：F2  IDL  07  00  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x07;
	        protocolDataItem.Data[3] = 0;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x07+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }




        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : SetPresettingBit
        功能     : (设置预置位)  创建一条矩阵控制协议数据，用于设置预置位。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
		           [IN] presettingBit：预置位 (01-0x80)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem SetPresettingBit(int decoderNum, byte presettingBit)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("SetPresettingBit())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //设置预置位
	        //数据：F2  IDL  13  PRE  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //PRE:预置位 (01-0x80)

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x13;
	        protocolDataItem.Data[3] = presettingBit;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x13+presettingBit+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : UsePresettingBit
        功能     : (调用预置位)  创建一条矩阵控制协议数据，用于调用预置位。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
                   [IN] presettingBit：预置位 (01-0x80)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem UsePresettingBit(int decoderNum, byte presettingBit)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("UsePresettingBit())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //调用预置位 
	        //数据：F2  IDL  14  PRE  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位
	        //PRE:预置位 (01-0x80)

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x14;
	        protocolDataItem.Data[3] = presettingBit;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x14+presettingBit+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Aid1_Enable
        功能     : (辅助1 开)  创建一条矩阵控制协议数据，用于辅助1 开。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Aid1_Enable(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Aid1_Enable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //辅助1 开/关 
	        //数据：F2  IDL  11/12  01  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x11;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x11+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Aid1_Disable
        功能     : (辅助1关)  创建一条矩阵控制协议数据，用于辅助1关。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Aid1_Disable(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Aid1_Disable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //辅助1 开/关 
	        //数据：F2  IDL  11/12  01  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x12;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x12+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Aid2_Enable
        功能     : (辅助2 开)  创建一条矩阵控制协议数据，用于辅助2 开。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Aid2_Enable(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Aid2_Enable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //辅助2 开/关 
	        //数据：F2  IDL  11/12  02  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x11;
	        protocolDataItem.Data[3] = 0x02;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x11+0x02+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : Aid2_Disable
        功能     : (辅助2关)  创建一条矩阵控制协议数据，用于辅助2关。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem Aid2_Disable(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("Aid2_Disable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //辅助2 开/关 
	        //数据：F2  IDL  11/12  02  00  00  CH   IDH
	        //ID:解码器号码（01-0x400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x12;
	        protocolDataItem.Data[3] = 0x02;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x12+0x02+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }



        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_EnableAutoScan
        功能     : (云台自动扫描开)  创建一条矩阵控制协议数据，用于云台自动扫描开关。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_EnableAutoScan(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_EnableAutoScan())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //云台自动扫描开
	        //数据：F2  IDL  11  09   00  00  CH   IDH
	        //ID:解码器号码（01-400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x11;
	        protocolDataItem.Data[3] = 0x09;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x11+0x09+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : PTZControl_DisableAutoScan
        功能     : (云台自动扫描关)  创建一条矩阵控制协议数据，用于云台自动扫描关。
        参数     : [IN] decoderNum :   解码器号（01-0x400）
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem PTZControl_DisableAutoScan(int decoderNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("PTZControl_DisableAutoScan())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //云台自动扫描开
	        //数据：F2  IDL  12  09   00  00  CH   IDH
	        //ID:解码器号码（01-400）
	        //IDL：解码器低8位    
	        //IDH：解码器高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF2;
	        protocolDataItem.Data[1] = (byte)(decoderNum);//IDL：解码器低8位
	        protocolDataItem.Data[2] = 0x12;
	        protocolDataItem.Data[3] = 0x09;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(decoderNum>>8);//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x12+0x09+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }




        ///////////////////////////////////////////////
        //报警相关：
        ///////////////////////////////////////////////


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ARM_Fortify
        功能     : (报警主机设防)  创建一条矩阵控制协议数据，用于报警主机设防。
        参数     : [IN] alarmSiteNum :   警点号码（01-0x200）(可以是0，代表所有有警点)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ARM_Fortify(int alarmSiteNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ARM_Fortify())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //报警主机设防	
	        //数据：F6  ARML 41 01 00 00 CH  ARMH
	        //ARM: 警点号码（01-0x200）(可以是0，代表所有有警点)
	        //ARML:警点号码低8位
	        //ARMH:警点号码高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF6;
	        protocolDataItem.Data[1] = (byte)(alarmSiteNum);//ARML：警点号码低8位
	        protocolDataItem.Data[2] = 0x41;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(alarmSiteNum>>8);//ARMH：警点号码高8位
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x41+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ARM_Fortify_Disable
        功能     : (报警主机撤防)  创建一条矩阵控制协议数据，用于报警主机撤防。
        参数     : [IN] alarmSiteNum :   警点号码（01-0x200）(可以是0，代表所有有警点)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ARM_Fortify_Disable(int alarmSiteNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ARM_Fortify_Disable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //报警主机撤防
	        //数据：F6  ARML 42 01 OO 00 CH  ARMH
	        //ARM: 警点号码（01-0x200）(可以是0，代表所有有警点)
	        //ARML:警点号码低8位
	        //ARMH:警点号码高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF6;
	        protocolDataItem.Data[1] = (byte)(alarmSiteNum);//ARML：警点号码低8位
	        protocolDataItem.Data[2] = 0x42;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(alarmSiteNum>>8);//ARMH：警点号码高8位
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x42+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ARM_CancelAlarm
        功能     : (报警主机消警)  创建一条矩阵控制协议数据，用于报警主机消警。
        参数     : [IN] alarmSiteNum :   警点号码（01-0x200）(可以是0，代表所有有警点)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ARM_CancelAlarm(int alarmSiteNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ARM_CancelAlarm())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //报警主机消警
	        //数据：F6  ARML 43 01 00 00 CH   ARMH
	        //ARM: 警点号码（01-200）(可以是0，代表所有有警点)
	        //ARML:警点号码低8位
	        //ARMH:警点号码高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF6;
	        protocolDataItem.Data[1] = (byte)(alarmSiteNum);//ARML：警点号码低8位
	        protocolDataItem.Data[2] = 0x43;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(alarmSiteNum>>8);//ARMH：警点号码高8位
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x43+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ARM_Linkage_Enable
        功能     : (报警主机联动输出开)  创建一条矩阵控制协议数据，用于报警主机联动输出开。
        参数     : [IN] alarmSiteNum :   警点号码（01-0x200）(可以是0，代表所有有警点)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ARM_Linkage_Enable(int alarmSiteNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ARM_Linkage_Enable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //报警主机联动输出开
	        //数据：F6  ARML 44 01 00 00 CH  ARMH
	        //ARM: 警点号码（01-200）(可以是0，代表所有有警点)
	        //ARML:警点号码低8位
	        //ARMH:警点号码高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF6;
	        protocolDataItem.Data[1] = (byte)(alarmSiteNum);//ARML：警点号码低8位
	        protocolDataItem.Data[2] = 0x44;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(alarmSiteNum>>8);//ARMH：警点号码高8位
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x44+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ARM_Linkage_Disable
        功能     : (报警主机联动输出关)  创建一条矩阵控制协议数据，用于报警主机联动输出关。
        参数     : [IN] alarmSiteNum :   警点号码（01-0x200）(可以是0，代表所有有警点)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ARM_Linkage_Disable(int alarmSiteNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ARM_Linkage_Disable())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        //报警主机联动输出关
	        //数据:F6 ARML 45 01 00 00 CH  ARMH
	        //ARM: 警点号码（01-200）(可以是0，代表所有有警点)
	        //ARML:警点号码低8位
	        //ARMH:警点号码高8位

	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF6;
	        protocolDataItem.Data[1] = (byte)(alarmSiteNum);//ARML：警点号码低8位
	        protocolDataItem.Data[2] = 0x45;
	        protocolDataItem.Data[3] = 0x01;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = (byte)(alarmSiteNum>>8);//ARMH：警点号码高8位
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)((protocolDataItem.Data[1])+0x45+0x01+(byte)(protocolDataItem.Data[7]));

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ARM_AlarmQuery
        功能     : (报警查询)  创建一条矩阵控制协议数据，用于报警查询。
        参数     : [IN] nAlarmHostNum :   警点号码（01-0x200）(可以是0，代表所有有警点)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ARM_AlarmQuery(byte nAlarmHostNum)
        {
            /*#########运行时日志 2010-03-11新增###########*/
            //RunLog("ARM_AlarmQuery())", "MatrixProtocolBuilder.cpp");
            /*#############################################*/

            //报警查询
            //数据：F6  GARM 4A 10 00 00 CH  00
            //
            //报警主机回送：F6  GARM 4B 10 DATA1 DATA2 CH  00
            //GARM: 报警主机号码（01-20）(一台报警主机有16路警点)
            //DATA1，DATA2: 警情位功能（1:有警；0:无警）
            //DATA1：16路报警主机的低8路
            //DATA2：16路报警主机的高8路

            ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
             
            protocolDataItem.Data[0] = 0xF6;
            protocolDataItem.Data[1] = nAlarmHostNum;//报警主机号码（01-20）
            protocolDataItem.Data[2] = 0x4A;
            protocolDataItem.Data[3] = 0x10;
            protocolDataItem.Data[4] = 0;
            protocolDataItem.Data[5] = 0;
            protocolDataItem.Data[7] = 0;//ARMH：警点号码高8位
            //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
            protocolDataItem.Data[6] = (byte)(nAlarmHostNum + 0x4A + 0x10);

            return protocolDataItem;
        }



        //////////////////////////////////////////////////////////////////////////////////
        //切换控制：
        //////////////////////////////////////////////////////////////////////////////////


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ProgramChange
        功能     : (程序切换)  创建一条矩阵控制协议数据，用于程序切换。
        参数     : [IN] byMonitorNum : 监视器号(01-0x80)
		           [IN] PrormNum :	   程序号
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ProgramChange(byte byMonitorNum, byte PrormNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ProgramChange())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        /*程序切换
	        数据：F4 00  27  MON  TU  00  CH   00
	        MON:监视器号(01-80)    TU: 程序组号(00-40)
	        */
	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF4;
	        protocolDataItem.Data[1] = 0;
	        protocolDataItem.Data[2] = 0x27;
	        protocolDataItem.Data[3] = byMonitorNum;
	        protocolDataItem.Data[4] = PrormNum;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = 0;//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)(protocolDataItem.Data[1] + protocolDataItem.Data[2] + (byte)(protocolDataItem.Data[3]) + (byte)(protocolDataItem.Data[4]) + protocolDataItem.Data[5]);

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ProgramFormerChange
        功能     : (前切)  创建一条矩阵控制协议数据，用于前切。
        参数     : [IN] byMonitorNum : 监视器号(01-0x80)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ProgramFormerChange(byte byMonitorNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ProgramFormerChange())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        /*F4 00  2C  MON  00  00  CH   00*/
	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF4;
	        protocolDataItem.Data[1] = 0;
	        protocolDataItem.Data[2] = 0x2C;
	        protocolDataItem.Data[3] = byMonitorNum;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = 0;//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte)(protocolDataItem.Data[1] + protocolDataItem.Data[2] + (byte)(protocolDataItem.Data[3])  + protocolDataItem.Data[5]);

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ProgramNextChange
        功能     : (后切)  创建一条矩阵控制协议数据，用于后切。
        参数     : [IN] byMonitorNum : 监视器号(01-0x80)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ProgramNextChange(byte byMonitorNum)
        {
 	        /*#########运行时日志 2010-03-11新增###########*/
	        //RunLog("ProgramNextChange())", "MatrixProtocolBuilder.cpp");
	        /*#############################################*/

	        /*F4  00  2B  MON  00  00  CH   00*/
	        ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
	          
	        protocolDataItem.Data[0] = 0xF4;
	        protocolDataItem.Data[1] = 0;
	        protocolDataItem.Data[2] = 0x2B;
	        protocolDataItem.Data[3] = byMonitorNum;
	        protocolDataItem.Data[4] = 0;
	        protocolDataItem.Data[5] = 0;
	        protocolDataItem.Data[7] = 0;//IDH：解码器高8位;
	        //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
	        protocolDataItem.Data[6] = (byte) (protocolDataItem.Data[1] + protocolDataItem.Data[2] + (byte)(protocolDataItem.Data[3])  + protocolDataItem.Data[5]);

	        return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : GroupSwitch
        功能     : (群组切换)  创建一条矩阵控制协议数据，用于群组切换。
        参数     : [IN] byMonitorNum : 监视器号(01-0x80)
		           [IN] nQueueNum :	   群组号(00-0x40)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem GroupSwitch(byte byMonitorNum, byte nQueueNum)
        {
            /*#########运行时日志 2010-03-11新增###########*/
            //RunLog("GroupSwitch())", "MatrixProtocolBuilder.cpp");
            /*#############################################*/

            //数据：F4 00  28  MON  GP  00  CH   00
            //MON:监视器号(01-80)    GP:群组号(00-40)
            ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
             
            protocolDataItem.Data[0] = 0xF4;
            protocolDataItem.Data[1] = 0;
            protocolDataItem.Data[2] = 0x28;
            protocolDataItem.Data[3] = byMonitorNum;
            protocolDataItem.Data[4] = nQueueNum;
            protocolDataItem.Data[5] = 0;
            protocolDataItem.Data[7] = 0;
            //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
            protocolDataItem.Data[6] = (byte)(0x28 + byMonitorNum + nQueueNum);

            return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : SynchronousSwitch
        功能     : (同步切换)  创建一条矩阵控制协议数据，用于同步切换。
        参数     : [IN] byMonitorNum : 监视器号(01-0x80)
		           [IN] nQueueNum :	   同步切换组号(00-0x40)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem SynchronousSwitch(byte byMonitorNum, byte nQueueNum)
        {
            /*#########运行时日志 2010-03-11新增###########*/
            //RunLog("SynchronousSwitch())", "MatrixProtocolBuilder.cpp");
            /*#############################################*/

            //数据：F4 00  29  MON  SA  00  CH   00
            //MON:监视器号(01-80)   SA:同步切换组号(00-40)
            ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
             
            protocolDataItem.Data[0] = 0xF4;
            protocolDataItem.Data[1] = 0;
            protocolDataItem.Data[2] = 0x29;
            protocolDataItem.Data[3] = byMonitorNum;
            protocolDataItem.Data[4] = nQueueNum;
            protocolDataItem.Data[5] = 0;
            protocolDataItem.Data[7] = 0;
            //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
            protocolDataItem.Data[6] = (byte)(0x29 + byMonitorNum + nQueueNum);

            return protocolDataItem;
        }


        /*! @function
        ********************************************************************************
        <PRE>
        函数名   : ImageHold
        功能     : (图像保持)  创建一条矩阵控制协议数据，用于图像保持。
        参数     : [IN] byMonitorNum : 监视器号(01-0x80)
        返回值   : 协议数据ProtocolDataItem结构体变量
        </PRE>
        *******************************************************************************/
        public ProtocolDataItem ImageHold(byte byMonitorNum)
        {
            /*#########运行时日志 2010-03-11新增###########*/
            //RunLog("ImageHold())", "MatrixProtocolBuilder.cpp");
            /*#############################################*/

            //数据:F4  00  2D  MON  00  00  CH   00
            //MON:监视器号(01-80)
            ProtocolDataItem protocolDataItem = new ProtocolDataItem(MyConstant.ProtocolDatalen);
             
            protocolDataItem.Data[0] = 0xF4;
            protocolDataItem.Data[1] = 0;
            protocolDataItem.Data[2] = 0x2D;
            protocolDataItem.Data[3] = byMonitorNum;
            protocolDataItem.Data[4] = 0;
            protocolDataItem.Data[5] = 0;
            protocolDataItem.Data[7] = 0;//IDH：解码器高8位;
            //第7字节是数据校验码：Check = 字节2 + 字节3 + 字节4 + 字节5 + 字节6 + 字节8。
            protocolDataItem.Data[6] = (byte)(0x2D + byMonitorNum);

            return protocolDataItem;
        }

    }

}
