/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2014-11-18 18:32:33
 * @version $Id$
 */
 eboxC = "";
(function(){
	function eboxTest(){
		ReInit:function(){
			eboxC.ReInit();
		},
		InitIdCard : function(){

		},
		SetBizCode : function(){

		},
		stopCheckDoor : function(){

		},
		//
		GetUiData : function(){
			return ;
		},
		openStoreExpress : function(){

		},
		validateBoxDoorStatus :function(){

		},
		InitBarCodeScannerToRead : function(){

		},
		CheckOrderByBarCode :function(){

		},
		//json
		queryTimeAndForbidden : function(){

		},
		//json
		openStoreExpress : function(){

		},
		//json
		GetFreeMouthList : function(){

		},
		validateBarCode : function(barcode,phone,mouthTypeId){
			if(eboxC.isConnected()){
				return eboxC.validateBarCode(barcode,phone,mouthTypeId);
			}
		},
		//json
		saveStoreExpress : function(){

		},
		finishGetExpress : function(){

		},
		//json
		validateQRCode  :function(){

		},
		CustQuJian : function(){

		},
		SetBizCode : function(){

		},
		//json
		paymentOvertimeExpress : function(){

		},
		//json
		validateMoney : function(){

		},
		userSMSRecharge : function(){

		},
		//json
		orderCheckExpress : function(){

		},
		//json
		loadSysInfo : function(){

		},
		OpenBoxByArkId : function(){

		},
		modifyMouthArk : function(){

		},
		//json
		loadAllMouthList :function(){

		},
		StartCamera : function(){

		},
		CloseCamera : function(){

		},
		Snapshot :function(){

		},
		//json
		GetPBoxConfig : function(){

		},
		GetJiJianInfo : function(){

		},
		//json
		GetProviceList : function(){

		},
		SaveJiJianInfo : function(){

		},
		//json
		GetCityList : function(){

		},
		//json
		GetCountyList : function(){

		},
		//json
		GetLogisticsCompanyConfig : function(){

		},
		SetCmpID : function(){

		},
		InitElcWeight : function(){

		},
		StopWeightRead : function(){

		},
		memberConfig : function(){

		},
		setMemberCenterMoney : function(){

		},
		//json
		loadUserExpress : function(){

		},
		setOpenBoxAttr : function(){

		},
		closeExpress : function(){

		},
		//json
		loadExceptionExpress : function(){

		},
		loadOvertimeExpress : function(){

		},
		Login : function(){

		},
		//json
		registrationVerify : function(){

		},
		//json
		userRegist : function(){

		},
		startCheckDoor : function(){

		},

	};
	window.ebox = eboxTest();
})
