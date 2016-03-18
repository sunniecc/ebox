// index.html

function audio(){
	eboxembed.stop();
	em0.stop();
	em1.stop();
	em2.stop();
	em3.stop();
	em4.stop();
	em5.stop();
	em6.stop();
	em7.stop();
	em8.stop();
	em9.stop();
}

$(".exit").click(function(){
	timeout = 1000;
	timerBoo = true;
	usertype = 0;
    tail(false);
});

$(".enter").click(function(){
    timerBoo = false;
});
function camera(){
ebox.StartCamera();
t = setInterval(function() { 
	timegetCamera();
}, 1500);
};
var timetxt1 = 0;
function timegetCamera(){
	timetxt1++;
	if(timetxt1==4){
		clearInterval(t);
		ebox.CloseCamera();
		timetxt1=0;
		return false;
	}
	ebox.Snapshot();
}


var mutho = $('#box div');
var i = 0;
function eboxChangeColor(){	
	if(i != 0){
		mutho[i-1].style.background = "url(i/3.png)";
	}
}

function mutho3Imgp(){
	if(i != 0){
		mutho[i-1].style.background = "url(i/3-1.png)";
	}
	i = 0;
}


function tail(xx){
	if(xx){
		//$("#fotwe").attr("style","display: none;");
		//$("#fotweTwo").prop("disabled",false);
		$("#fotwe").hide();
		$("#fotweTwo").show();
	}else{
		//$("#fotwe").prop("disabled",false);
		//$("#fotweTwo").attr("style","display: none;");
		$("#fotwe").show();
		$("#fotweTwo").hide();
	}
}

/**
 * 取件，密码输入页面，返回按钮
 * @return {[type]} [description]
 */
$(".returnMian").click(function(){
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t2').attr("class", "info_t");
	$('.info_t').attr("class", "info_t3");
	$('.text').attr("class", "text1");
	$('.keyboard').attr("class", "keyboard1");
	inall.style.backgroundImage = "url(images/keyboard.jpg)";
});


/**
 * 编号为index 一下代码是index.html的代码 改页面里面有1个jqruey默认方法, 0个方法
 */
function index1() {
	alert("是你在控制时间");
	// 终止一个setTimeout设置的时间，这里是终止60s返回主界面的定时方法
	// doTimeout实现事件延迟触发功能
	$(this).doTimeout('EBOX2001', 200, function() {
		// 初始化
		ebox.ReInit();
	});
	inall.style.backgroundImage = "url(images/keyboard.jpg)";
	//int1.style.backgroundImage = "url(images/top.jpg)";
	//fotwe.style.backgroundColor = "#330066";
	id = initialize;
}
$(function() {
	index1();
})
// 查件身份证
// 管理员登录身份证页面
var timed = 0;
$('.amdroiLog').click(function() {
	$("#txtUserName").val("輸入用戶名");
	$("#txtPassword").val("");
	$('.info5_c').attr("class", "info5_c1");
	$('.info_t').attr("class", "info_t2");
	$('.info_t0').attr("class", "info_t");
	$('.info18_c2').attr("class", "info18_c");
	inall.style.backgroundImage = "url(images/imgs/UI_2_01/allbg.png)";
	tail(true);
	audio();
	fotwe.style.backgroundColor = "#0f1116";
	em0.play();
	admin();
})
/**
 * 管理登录界面
 */
function admin() {
	ebox.SetBizCode('EBOX2033');
	ebox.InitIdCard(3, 4);
	var uiData = json(ebox.GetUiData());
	var userName = uiData.UserName;
	if (null != userName && '' != userName) {
		$("#txtUserName").val(userName);

		/*
		 * if(len == 18 || len == 15){ $("#txtUserName").val(userName); }else{
		 * if('1' == userName.substring(0,1)){
		 * $("#txtUserName").val(userName.substring(1)); }else{
		 * $("#txtUserName").val(userName.substring(2)); } }
		 */
	}
	$("#btnLogin0").off();
	$("#btnLogin0").click(clickBing(function() {//时间绑定到登录按钮
		if ($.trim($("#txtUserName").val()) == '') {
			ms('系統提示', '請輸入登錄手機');
			return;
		}
		if ($.trim($("#txtPassword").val()) == '') {
			ms('系統提示', '請輸入登錄密碼');
			return;
		}
		var tel = $("#txtUserName").val();
		var r = ebox.Login(tel, $("#txtPassword").val());//请求c# 登录方法，获得数据
		if (!r) {//失败
			ms('系統提示', '用戶名或密碼錯誤');
			$("#txtUserName").val('輸入用戶名');
			$("#txtPassword").val('');
		} else {//成功
			var newData = json(ebox.GetUiData());//获得用户数据
			var userInfo = newData.UserInfo;
			if (userInfo.userInfo == null) {// 等于 null 网络中断
				alert('連接服務器超時，請重試');
				window.location.reload();
				// return;
			} else {
				uiData.Method == 4;
				usertype = 3;
				adm();//进入管理员登录界面
			}
		}
	}));
}
function UserValidated(str) {
	var j = json(str);
	if (j.success)
		admin();
	else
		// ms('系統提示','管理员身份证不存在');
		alert('管理員身份證不存在');
	index2();
}
function index2() {
	audio();
	$('.info5_c1').attr("class", "info5_c");//info5_c{}  info5_c在index文件中
	$('.info_t').attr("class", "info_t0");//info_t0在index文件中
	$('.info_t2').attr("class", "info_t");//info_t是系统信息开始中的样式  info_t2在index文件中
	$('.info18_c').attr("class", "info18_c2");//info18_c 是数字简单的演示？？？？ info18_c2
	em10.stop();//启动音频
	index1();
	tail(false);
}
// 管理员登录首页
function adm() {
	audio();
	$('.info18_c').attr("class", "info18_c2");
	$('.info3_c1').attr("class", "info3_c");//info3_c{}
	em0.stop();
	em10.play();
	adm1();
}
function index3() {
	audio();
	$('.info3_c').attr("class", "info3_c1");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	em10.stop();
	index1();
}
$("#index3").click(function() {
	audio();
	$('.info3_c').attr("class", "info3_c1");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	//$('.info_t2').attr("class", "info_t");
	em10.stop();
	index1();
	tail(false);
});
function adm1() {
	ebox.SetBizCode('EBOX2035');
	$(this).doTimeout('EBOX2035', lazyTime, function() {
		loadAdminInfo();
	});
}
function loadAdminInfo() {
	var v = json(ebox.GetUiData()).UserInfo;
	var authz = v.terminalFunction;
	if (null == authz || authz == undefined) {
		ms('系統提示', '系統未授權');
		return;
	}
	$("#adminname").text(v.userInfo.uiLoginName);
	$("#adminphone").text(v.userInfo.uiUserPhone);
	$("#adminunit").text(v.userInfo.uiDeptName);
	for (var i = 0; i < authz.length; i++) {
		$("#ebox" + authz[i].tfFuncNo).show();
	}
	var cnt = json(ebox.openStoreExpress());
	if (cnt.custExpress > 0) {
		$("#ebox5").append("<span>" + cnt.custExpress + "</span>");
	}
	if (cnt.overtimeExpress > 0) {
		$("#ebox3").append("<span>" + cnt.overtimeExpress + "</span>");
	}
	if (cnt.exceptionExpress > 0) {
		$("#ebox4").append("<span>" + cnt.exceptionExpress + "</span>");
	}
}
function projectExit() {
	if (confirm('確認退出系統？')) {
		ebox.Exit();
	}
}
// 系统信息返回管理员登录首页界面
function toadmin() {
	audio();
	$('.info3_c1').attr("class", "info3_c");
	$('.info_c').attr("class", "info_c1");
	em10.play()
	adm1();
}
function index6() {
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	$('.info_c').attr("class", "info_c1");
	index1();
}
// 系统信息
function sysinfo() {
	$('.info3_c').attr("class", "info3_c1");
	$('.info_c1').attr("class", "info_c");

	$(".modify")
			.click(clickBing(
					function() {
						var urlid = $(this).attr("id");// id表示
						if (urlid == '03') {
							var r = window
									.showModalDialog("格口价格修改.html", window,
											"dialogWidth=1000px;dialogHeight=550px;status=no;resizable=no;");
							if (r == 1) {
								window.location.reload();
							}
						}
					}));
	$(this).doTimeout('EBOX2036', lazyTime, function() {
		loadSysInfoList();
	});
	ebox.SetBizCode('EBOX2036');
}
function loadSysInfoList() {
	var v = json(ebox.loadSysInfo());
	if (null != v.op && v.op.length > 0) {
		$("#opName").text(v.op[0].opName);
		$("#opNo").text(v.op[0].opNo);
		$("#opContacts").text(v.op[0].opContacts);
		$("#opConPhone").text(v.op[0].opConPhone);
		$("#opAddress").text(v.op[0].opAddress);
	}
	if (null != v.sys && v.sys.length > 0) {
		$("#sysNo").text(v.sys[0].pbCrtNo);
		$("#sysAbbr").text(v.sys[0].pbAbbr);
		$("#sysStoreNum").text(v.sys[0].storeNum);
		$("#sysMouthNum").text(v.sys[0].mouthNum);
	}
	if (null != v.version) {
		$("#sysVersion").text(v.version.version);
	}
	if (null != v.mouth) {
		var list = v.mouth;
		var mouthInfo = '';
		var rowCount = Math.floor(list.length % 2 == 0 ? list.length / 2
				: list.length / 2 + 1);

		for (var i = 0; i < list.length; i++) {
			if (i % 2 == 0) {
				mouthInfo += '<tr>';
				mouthInfo += '<td width="152" '
						+ (i == 0 ? ' height="30" ' : '')
						+ 'align="right" valign="bottom">' + list[i].moModel
						+ '</td>';
				mouthInfo += '<td width="33" valign="middle">&nbsp;</td>';
				mouthInfo += '<td width="51" align="left" valign="bottom">'
						+ list[i].moPrice + '</td>';
				mouthInfo += '<td width="69" align="left" valign="bottom">[ '
						+ list[i].buzStatusName + '］</td>';
			} else {
				mouthInfo += '<td  width="74"  align="right" valign="middle">'
						+ list[i].moModel + '</td>';
				mouthInfo += '<td  width="81"  align="center" valign="middle">'
						+ list[i].moPrice + '</td>';
				mouthInfo += '<td   width="167" align="left" valign="middle">[ '
						+ list[i].buzStatusName + '］</td>';
			}

			if (i == 0) {
				mouthInfo += '<td width="267" rowspan="' + rowCount
						+ '" align="center" valign="bottom"></td>';
			}
			if (i % 2 == 1) {
				mouthInfo += '</tr>';
			}
		}
		$("#mouthList").html(mouthInfo);
	}
}
// 取寄件
function getsend() {
	audio();
	$('.info1_c2').attr("class", "info1_c");
	$('.info3_c').attr("class", "info3_c1");

	em10.stop();
	em5.play();
	sender1();
	ebox.SetBizCode('EBOX2021');
	sender2();
}
function index7() {
	audio();
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	$('.info1_c').attr("class", "info1_c2");
	em5.stop();
	index1();
}
function sender1() {
	$(".che").live("click", function() {
		if ($(this).find('input').attr("checked")) {
			$(this).find("img").attr("src", "images/info/checkbox1.png");
			$(this).find("input").attr("checked", false);
			$(this).find("input").val('0');
		} else {
			$(this).find("img").attr("src", "images/info/checkbox2.png");
			$(this).find("input").attr("checked", "true");
			$(this).find("input").val('1');
		}
	});
	ebox.SetBizCode('EBOX2021');
	var uiData = json(ebox.GetUiData());
	var usertype = uiData.UserType;
}
function getSelectItem2() {
	var idArr = [], lockArr = [];
	$(".tableborder2 tbody tr").each(function() {
		$(this).find("input[type=checkbox]").each(function() {
			if ($(this).attr("checked")) {
				idArr.push($(this).attr("bizId"));
				lockArr.push($(this).attr("lockNo"));
			}
		});
	});
	openBox2(idArr, lockArr);
}
function getAllItem2() {
	var idArr = [], lockArr = [];
	$(".tableborder2 tbody tr").each(function() {
		$(this).find("input[type=checkbox]").each(function() {
			idArr.push($(this).attr("bizId"));
			lockArr.push($(this).attr("lockNo"));
		});
	});
	openBox2(idArr, lockArr);
}

function openBox2(idArr, lockArr) {
	camera();
	if (null == idArr || idArr.length == 0) {
		ms('系統提示', '請選擇寄件項');
		return;
	}
	var monos = ebox.setOpenBoxAttr(idArr);
	geturl('mouthopen1()?monos=' + monos);
}
$('#back3').click(function() {
	$('.info1_c').attr("class", "info1_c2");
	$('.info3_c1').attr("class", "info3_c");
	adm1();
});
function sender2() {
	var expressList = json(ebox.loadUserExpress());
	var bodylist = '<tr class="f20 f_f fyh img_2">';
	for (var i = 0; i < expressList.length; i++) {
		bodylist += '<tr class="f20 f_f fyh img_2">'
		bodylist += '<td height="50" class="p_l15 che">'
		bodylist += '<input name="id" type="checkbox" value="" bizId="'
				+ expressList[i].eiId
				+ '" lockNo="'
				+ (expressList[i].moLockNo ? expressList[i].moLockNo : '')
				+ '" /><img src="images/info/checkbox1.png" />'
				+ (expressList[i].eiStoreUserName ? expressList[i].eiStoreUserName
						: '') + '</td>';
		bodylist += '<td>'
				+ (expressList[i].eiStoreUserPhone ? expressList[i].eiStoreUserPhone
						: '') + '</td>';
		bodylist += '<td>'
				+ (expressList[i].eiStoreTime ? expressList[i].eiStoreTime : '')
				+ '</td>';
		bodylist += '<td>'
				+ (expressList[i].eiLatticeNo ? expressList[i].eiLatticeNo : '')
				+ '</td>';
		bodylist += '<td>'
				+ (expressList[i].eiCityName ? expressList[i].eiCityName : '')
				+ '</td>';
		bodylist += '<td>'
				+ (expressList[i].eiPaymentMoney ? expressList[i].eiPaymentMoney
						: '') + '</td>';
		bodylist += '</tr>';
	}
	$('.tableborder2 tr:gt(0)').remove();
	$(".tableborder2 tr:eq(0)").after(bodylist);
}
// 取异常件
function getexcep() {
	audio();
	$('.info1_c3').attr("class", "info1_c");
	$('.info3_c').attr("class", "info3_c1");

	em10.stop();
	em5.play();
	excepexp1();
}
function index8() {
	audio();
	$('.info1_c').attr("class", "info1_c3");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	em5.stop();
	index1();
}
function excepexp1() {
	$(".che").live("click", function() {
		if ($(this).find('input').attr("checked")) {
			$(this).find("img").attr("src", "images/info/checkbox1.png");
			$(this).find("input").attr("checked", false);
		} else {
			$(this).find("img").attr("src", "images/info/checkbox2.png");
			$(this).find("input").attr("checked", "checked");
		}
	});

	ebox.SetBizCode('EBOX2025');
	var uiData = json(ebox.GetUiData());
	var usertype = uiData.UserType;
	$(this).doTimeout('EBOX2025', lazyTime, function() {
		loadExceptionExpressList();
	});
	$('#back2').click(function() {
		$('.info1_c').attr("class", "info1_c3");
		$('.info3_c1').attr("class", "info3_c");
		adm1();
	});
}

function openBox4(idArr, lockArr) {
	if (null == idArr || idArr.length == 0) {
		ms('系統提示', '請選擇寄件項');
		return;
	}
	camera();
	ebox.setOpenBoxAttr(idArr);
	mouthopen2();
}
function getSelectItem4() {
	var idArr = [], lockArr = [];
	$(".tableborder4 tbody tr").each(function() {
		$(this).find("input[type=checkbox]").each(function() {
			if ($(this).attr("checked")) {
				idArr.push($(this).attr("bizId"));
				lockArr.push($(this).attr("lockNo"));
			}
		});
	});
	openBox4(idArr, lockArr);
}
function getAllItem4() {
	var idArr = [], lockArr = [];
	$(".tableborder4 tbody tr").each(function() {
		$(this).find("input[type=checkbox]").each(function() {
			idArr.push($(this).attr("bizId"));
			lockArr.push($(this).attr("lockNo"));
		});
	});
	openBox4(idArr, lockArr);
}
function loadExceptionExpressList() {
	var expressList = json(ebox.loadExceptionExpress());
	var bodylist = '<tr class="f20 f_f fyh img_2">';
	for (var i = 0; i < expressList.length; i++) {
		var remark = '';
		if (expressList[i].eoRemark == '1') {
			remark = '快件破损';
		} else if (expressList[i].eoRemark == '2') {
			remark = '不是我的快件';
		} else if (expressList[i].eoRemark == '3') {
			remark = '快件不符';
		} else {
			remark = '其他';
		}
		bodylist += '<tr class="f20 f_f fyh img_2">'
		bodylist += '<td height="50" class="p_l15 che">'
		bodylist += '<input name="id" type="checkbox" value="" bizId="'
				+ expressList[i].eiId + '" lockNo="' + expressList[i].moLockNo
				+ '" /><img src="images/info/checkbox1.png" />'
				+ expressList[i].eiBarcode + '</td>';
		bodylist += '<td>' + expressList[i].eiStoreUserPhone + '</td>';
		bodylist += '<td>' + expressList[i].eiStoreTime + '</td>';
		bodylist += '<td>' + expressList[i].eiLatticeNo + '</td>';
		bodylist += '<td>' + remark + '</td>';
		bodylist += '</tr>';
	}
	$('.tableborder4 tr:gt(0)').remove();
	$(".tableborder4 tr:eq(0)").after(bodylist);
}
// 管理员取逾期件
function getadmover() {
	audio();
	$('.info1_c3').attr("class", "info1_c");
	$('.info3_c').attr("class", "info3_c1");
	em10.stop();
	em5.play();
	overexp1();
	
}
$('#back2').click(function() {
	$('.info1_c').attr("class", "info1_c3");
	$('.info3_c1').attr("class", "info3_c");
});
function index9() {
	audio();
	$('.info1_c').attr("class", "info1_c1");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	em5.stop();
	index1();
}
function loadOvertimeExpressList() {
	var rst = ebox.loadOvertimeExpress();
	var expressList = json(rst);
	var bodylist = '<tr class="f20 f_f fyh img_2">';
	for (var i = 0; i < expressList.length; i++) {
		bodylist += '<tr class="f20 f_f fyh img_2">'
		bodylist += '<td height="50" class="p_l15 che">'
		bodylist += '<input name="id" type="checkbox" value="" bizId="'
				+ expressList[i].eiId + '" lockNo="' + expressList[i].moLockNo
				+ '" /><img src="images/info/checkbox1.png" />'
				+ expressList[i].eiBarcode + '</td>';
		bodylist += '<td>' + expressList[i].eiStoreUserPhone + '</td>';
		bodylist += '<td>' + expressList[i].eiStoreTime + '</td>';
		bodylist += '<td>' + expressList[i].eiLatticeNo + '</td>';
		bodylist += '<td>' + expressList[i].overTimeDay + '</td>';
		bodylist += '</tr>';
	}
	$('.tableborder3 tr:gt(0)').remove();
	$(".tableborder3 tr:eq(0)").after(bodylist);
}

function overexp1() {
	// 点击一个单选框，如果这个单选框已经被选中，则取消选中，如果这个单选框未被选中，则选中这个
	$(".che").live("click", function() {
		if ($(this).find('input').attr("checked")) {
			$(this).find("img").attr("src", "images/info/checkbox1.png");
			$(this).find("input").attr("checked", false);
		} else {
			$(this).find("img").attr("src", "images/info/checkbox2.png");
			$(this).find("input").attr("checked", "checked");
		}
	});
	ebox.SetBizCode('EBOX2023');
	var uiData = json(ebox.GetUiData());
	var usertype = uiData.UserType;
	$(this).doTimeout('EBOX2023', lazyTime, function() {
		loadOvertimeExpressList();
	});
}
var uiData = json(ebox.GetUiData());
var usertype = uiData.UserType;
function getSelectItem3() {
	var idArr = [], lockArr = [];
	$(".tableborder3 tbody tr").each(function() {
		$(this).find("input[type=checkbox]").each(function() {
			if ($(this).attr("checked")) {
				idArr.push($(this).attr("bizId"));
				lockArr.push($(this).attr("lockNo"));
			}
		});
	});
	openBox3(idArr, lockArr);
}
function getAllItem3() {
	var idArr = [], lockArr = [];
	$(".tableborder3 tbody tr").each(function() {
		$(this).find("input[type=checkbox]").each(function() {
			idArr.push($(this).attr("bizId"));
			lockArr.push($(this).attr("lockNo"));
		});
	});
	openBox3(idArr, lockArr);
}

function openBox3(idArr, lockArr) {
	if (null == idArr || idArr.length == 0) {
		ms('系統提示', '請選擇寄件項');
		return;
	}
	camera();
	ebox.setOpenBoxAttr(idArr);
	mouthopen();
}
function back1() {
	audio();
	usertype == 4;
	$('.info1_c').attr("class", "info1_c1");
	$('.info3_c1').attr("class", "info3_c");
	em5.stop();
	em10.play();
	adm1();
}
function back2() {
	audio();
	usertype == 3;
	$('.info1_c').attr("class", "info1_c1");
	$('.info2_c1').attr("class", "info2_c");
	em5.stop();
	em1.play();
	express();
}
// 管理员逾期格口打开
function mouthopen() {
	audio();
	alert("mouthopen");
	$('.info1_c').attr("class", "info1_c1");
	$('.info15_c1').attr("class", "info15_c");
	em5.stop();
	em6.play();
	mouthopen1();
}
function index10() {
	audio();
	$('.info_all1a').attr("class", "info_all1");
	$('.info_all3').attr("class", "info_all3a");
	em6.stop();
	//index1();
}
// 管理员寄件格口打开
function mouthopen2() {
	audio();
	$('.info1_c').attr("class", "info1_c3");
	$('.info15_c1').attr("class", "info15_c");

	em5.stop();
	em6.play();
	mouthopen1();
}
// 管理员异常件格口打开
function mouthopen3() {
	audio();
	$('.info1_c').attr("class", "info1_c3");
	$('.info15_c1').attr("class", "info15_c");

	em5.stop();
	em6.play();
	mouthopen1();
}
// 快递员逾期格口打开
function mouthopen4() {
	audio();
	$('.info1_c').attr("class", "info1_c1");
	$('.info15_c1').attr("class", "info15_c");

	em5.stop();
	em6.play();
	mouthopen1();
}
// 格口打开脚本
var uiData = json(ebox.GetUiData());
var usertype = uiData.UserType;
// 取寄件
var mouthopenInt ;
function mouthopen1() {
	mouthopenInt = window.setInterval("timeget3()", 1000);
	var v = json(ebox.GetUiData());
	$("#gridNum").text(v.JiJianMouthNo);
}
// 取逾期件
function mouthopen1a() {
	window.setInterval("timeget3a()", 1000);
	var v = json(ebox.GetUiData());
	$("#gridNum").text(v.JiJianMouthNo);
}
// 取异常件
function mouthopen1b() {
	window.setInterval("timeget3b()", 1000);
	var v = json(ebox.GetUiData());
	$("#gridNum").text(v.JiJianMouthNo);
}
var timegetBoo = false;
function timeget3() {
	if(timegetBoo){
		$(".time3").text(30);
		timegetBoo = false;
		return;
	}
	timetxt = $(".time3").text();
	if (timetxt < 0) {
		finish();
		//index10();
	}else{
		timetxt--
		$(".time3").text(timetxt);
	}
}
function finish() {
	timegetBoo = true;
	ebox.finishGetExpress();
	clearInterval(mouthopenInt);
	if (usertype == 4) {
		audio();
		$('.info2_c1').attr("class", "info2_c");
		$('.info15_c').attr("class", "info15_c1");
		em6.stop();
		em1.play();
		express();
	} else if (usertype == 3) {
		audio();
		$('.info3_c1').attr("class", "info3_c");
		$('.info15_c').attr("class", "info15_c1");
		em6.stop();
		em10.play();
		adm1();
	} else {
		audio();
		geturl('index.html');
		em6.stop();
	}
}
// 格口管理
function index11() {
	$('.info4_c').attr("class", "info4_c1");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	index1();
}
function gridto() {
	audio();
	$('.info4_c').attr("class", "info4_c1");
	$('.info3_c1').attr("class", "info3_c");
	em10.play()
	adm1();
}
function gridmanage(boo) {
	if(boo){//删除所有格口
		$(".overview").empty();
	}else{
		$('.info3_c').attr("class", "info3_c1");
		$('.info4_c1').attr("class", "info4_c");
	}
	//endSeconds = 60*10;
	
	ebox.SetBizCode('EBOX2037');
	$(this).doTimeout('EBOX2037', lazyTime, function() {
		loadSysMouthArk();
	});
	$('#scrollbar1').tinyscrollbar();
	$(".kk").live("click", function() {
		var gkid = $(this).attr("id");
		savegk(this);
	});
}
function savegk11(gksaveid) {
	var r = window.showModalDialog("格口修改.html", window,
			"dialogWidth=1000px;dialogHeight=550px;status=no;resizable=no;");
	if (r == 1) {
		window.location.reload();
	}
}
var mouthArkId = -1;
//快递员的存件，寄件
function savegk(gksaveid) {
							mouthArkId = $(gksaveid).attr('id');
							var exp = '';
							if ($(gksaveid).attr('state') === '使用') {
								exp = getExpressByMouthNo($(gksaveid).attr('no'));
							}
							var barcode = '', custPhone = '', kuaiDiPhone = '', kuaiDiName = '', kuaiDiComp = '';
							if ('' != exp && exp != undefined) {
								if (exp.eiMailType == '1') {
									// 寄件
									custPhone = exp.eiStoreUserPhone;
								} else {
									// 存件
									barcode = exp.eiBarcode;
									custPhone = exp.eiTakeUserPhone;
									kuaiDiPhone = exp.eiStoreUserPhone;
									kuaiDiName = exp.eiStoreUserName;
									kuaiDiComp = exp.eiLcName;
								}
							}
							a = new $.pos(
									{
										title : "",
										width : 900,
										center : true,
										top : 20,
										left : 30,// center：true
													// 左右上下居中、false自定义top,left。
										suburl : "index.php",
										opensuburl : "index.php",// 开锁url，传递id
										emptysuburl : "index.php",// 清空url，传递id
										formtitle : '<div class="con_tit dt"><div class="l gkt1">编号：<span id = "formtitle">'
												+ $(gksaveid).attr('no')
												+ '  '
												+ $(gksaveid).attr('state')
												+ '</span></div> <div class="r gkt2" ></div><div class="r gkt3" ></div></div>',
										id : $(gksaveid).attr('id'),
										no : $(gksaveid).attr('no'),
										state : $(gksaveid).attr('state'),
										form : [ {
											"name" : '箱门类型',
											'val' : $(gksaveid).attr('type'),
											'input' : 'n1',
											'option' : mouthTypeList,
											'barcode' : barcode,
											'custPhone' : custPhone
										}, {
											"name" : '设置状态',
											'val' : $(gksaveid).attr('state'),
											'input' : 'n3',
											'option' : '空闲|使用|占用',
											'kuaiDiPhone' : kuaiDiPhone,
											'kuaiDiName' : kuaiDiName
										}, {
											"name" : '箱门编号',
											'val' : $(gksaveid).attr('no'),
											'input' : 'n2',
											'value' : $(gksaveid).attr('no'),
											'kuaiDiComp' : kuaiDiComp
										} ]
									});
							a.show2();

}

function openDoor(arkId) {
	ebox.OpenBoxByArkId(mouthArkId);
}
function closediv(id) {
	$("." + id).remove();
	$(".allpost").remove();
}
function showdiv() {
	$("#allpost").hide();
	//$("#allpost").removeClass("allpost1");
	//$("#postt").removeClass("post");
}

function getExpressByMouthNo(no) {
	if ('' == expressList) {
		return '';
	}
	for (var i = 0; i < expressList.length; i++) {
		if (expressList[i].eiLatticeNo == no) {
			return expressList[i];
		}
	}
}
function closediv122(id) {
	var n1 = $("#n1").val();// 类型
	var n2 = $("#n2").val();// 编号
	var n3 = $("#n3").val();// 状态
	if (mouthArkId > 0) {
		if (isNaN(n2)) {
			alert('格口编号无效');
			return;
		}
		ebox.modifyMouthArk(mouthArkId, n1, n2, n3);
	}
	showdiv();
	gridmanage(true);
}
var mouthTypeList = '';
var mouthNoList = '';
var expressList = '';
function loadSysMouthArk() {
	mouthTypeList = '';
	var mouthArkJson = json(ebox.loadAllMouthList());
	var m = mouthArkJson.mouth;
	if (null != m && m.length > 0) {
		for (var i = 0; i < m.length; i++) {
			mouthTypeList += m[i].moModel + '|';
		}
		if (mouthTypeList.length > 0) {
			mouthTypeList = mouthTypeList
					.substring(0, mouthTypeList.length - 1);
		}
	}
	if (null != mouthArkJson.expressList && mouthArkJson.expressList.length > 0) {
		expressList = mouthArkJson.expressList;
	}
	var v = mouthArkJson.mouthArk;
	if (null != v && v.length > 0) {
		var mouthList = '';
		for (var i = 0; i < v.length; i++) {
			mouthNoList += v[i].moNo + '|';
			if ('1' == v[i].buzStatus) {// 空闲
				mouthList += "<div class='kk' type='" + v[i].moTypeName
						+ "' state='空闲' no='" + v[i].moNo + "' id='" + v[i].id
						+ "'>";
				mouthList += "<div class='k1'>" + v[i].moNo + "</div>";
			} else if ('2' == v[i].buzStatus) {// 使用
				mouthList += "<div class='kk' type='" + v[i].moTypeName
						+ "' state='使用' no='" + v[i].moNo + "' id='" + v[i].id
						+ "'>";
				mouthList += "<div class='k2'>" + v[i].moNo + "</div>";
			} else {// 系统占用
				mouthList += "<div class='kk' type='" + v[i].moTypeName
						+ "' state='占用' no='" + v[i].moNo + "' id='" + v[i].id
						+ "'>";
				mouthList += "<div class='k3'>" + v[i].moNo + "</div>";
			}
			if ('1' == v[i].moColor) {
				mouthList += "<div class='s1' style='background:#708069'>"
						+ v[i].moTypeName + "</div>";
			} else if ('2' == v[i].moColor) {
				mouthList += "<div class='s1' style='background:#00B0F0'>"
						+ v[i].moTypeName + "</div>";
			} else if ('3' == v[i].moColor) {
				mouthList += "<div class='s1' style='background:#7E649E'>"
						+ v[i].moTypeName + "</div>";
			} else if ('4' == v[i].moColor) {
				mouthList += "<div class='s1' style='background:#EA700D'>"
						+ v[i].moTypeName + "</div>";
			} else if ('5' == v[i].moColor) {
				mouthList += "<div class='s1' style='background:#31859B'>"
						+ v[i].moTypeName + "</div>";
			} else if ('6' == v[i].moColor) {
				mouthList += "<div class='s1' style='background:#BF9000'>"
						+ v[i].moTypeName + "</div>";
			}
			mouthList += "</div>";
		}
		$(".overview").html(mouthList);
	}
}
// 取件登录页面
$('.img1').click(function() {
	$('.info5_c').attr("class", "info5_c1");
	$('.info_t').attr("class", "info_t2");
	$('.info_t3').attr("class", "info_t");
	$('.text1').attr("class", "text");
	$('.keyboard1').attr("class", "keyboard");
	quj();
});
/**
 * 
 */
var id = initialize;
var initialize = 1;
function quj() {
	audio();
	inall.style.backgroundImage = "url(images/pick.jpg)";
	//int2.style.backgroundImage = "url(images/top.jpg)";
	em7.play();
	em9.stop();
	$('#1').val(" ");
	$('#2').val(" ");
	$('#3').val(" ");
	$('#4').val(" ");
	$('#5').val(" ");
	$('#6').val(" ");
	//var id = $(".txta").attr("id");//得到输入框的id数据，用来下面的识别
	if(id != 1){
		id = 1;
	}
	$(".keyboard div .key").unbind();
	//点击元素后触发事件，，，主要用来修改样式，背景图片
	$(".keyboard div .key").mousedown(
					function() {
						var id1 = $(this).text(); 
						if (id1 == "確定" || id1 == "删除") {
							this.style.background = "url(images/key1a.png) no-repeat";
						} else {
							this.style.background = "url(images/1a.png) no-repeat";
						}
					});
	//当鼠标点击后，松开 事件，，，主要用来修改样式，背景图片
	$(".keyboard div .key")
			.mouseup(
					function() {
						var id1 = $(this).text(); 
						if (id1 == "確定" || id1 == "删除") {
							this.style.background = "url(images/key1.png) no-repeat";
						} else {
							this.style.background = "url(images/1.png) no-repeat";
						}
					});
	//鼠标离开元素后时间，，主要用来修改样式，背景图片
	$(".keyboard div .key")
			.mouseleave(
					function() {
						var id1 = $(this).text(); 
						if (id1 == "確定" || id1 == "删除") {
							this.style.background = "url(images/key1.png) no-repeat";
						} else {
							this.style.background = "url(images/1.png) no-repeat";
						}
					});
			
	$(".keyboard div .key").click(
			function() {
				var s = $('#1').val() + $('#2').val() + $('#3').val()
						+ $('#4').val() + $('#5').val() + $('#6').val();
				if ($(this).text() == "删除") {
					if (id <= 1) {
						id = 1
					} else {
						id--;
					}
					$("#" + id).val(" ");
				} else if ($(this).text() == "確定") {
					$('#txt_yzmm').val(s);
					if ($.trim($('#txt_yzmm').val()) == '請輸入驗證碼'|| $.trim($('#txt_yzmm').val()) == '' || s.length < 5) {
						//ms('系統提示', "請輸入驗證碼");
						return;
					}
					submitQuJIan();//如果不是空，进行操作
				} else {
					$("#" + id).val($(this).text());
					if (id >= 6) {
						id = 7;
					} else {
						id++;
					}
					$('#txt_yzmm').val(s);
				}
				
			});
	$(".input3 img").click(function() {
		var mr = $(this).parent().find('input').attr('mr');
		$(this).parent().find('input').val(mr);
	});
};

function OnCodeScan(code) {
	var data = json(ebox.validateQRCode(code));
	if (null == data || data == '{}') {
		ms('系統提示', '讀取二維碼錯誤，請更換手機號及驗證碼再試');
		return;
	}
	$('#txt_tel').val(data.eiTakeUserPhone);
	$('#txt_yzmm').val(data.eiValidateCode);
	submitQuJIan();
}

function submitQuJIan() {
	var sum = al($('#txt_yzmm').val());
	// alert(sum);
	var r = json(ebox.CustQuJian("18612345678", sum));
	if (r.success) {
		if (r.status == '3') {
			if (r.type == 1010) {
				audio();
				expgridopen();
				em7.stop();
			} else {
				alert('走支付流程');
			}
		} else {
			if (r.type == 1010) {
				ms('系統提示', '您的快件已逾期，請交納逾期費用後再取件');
				// geturl('取件格口打开.html');
				geturl('逾期快件交费.html');
			} else {
				alert('走支付流程');
			}
		}

	} else {
		validfalse();
	}
	id = initialize
}
function toUrl(i) {
	if (i == true) {
		var r = eval('('
				+ ebox.QuJian($('#txt_tel').val(), $('#txt_yzmm').val()) + ')');
		if (r.success)
			geturl('协议-c.html');
		else {
			alert(r.msg);
		}
	} else {
		audio();
		em7.stop();
		expgridopen();
	}
}

function BoxClosed(id) {
	alert(id);
}
$("#bot13").click(function() {
	index12();
})
function index12() {
	audio();
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t3");
	$('.info_t2').attr("class", "info_t");
	$('.text').attr("class", "text1");
	$('.keyboard').attr("class", "keyboard1");
	em7.stop();
	index1();
}
var tuichu = false;
// 取件格口打开
function expgridopen() {
	mutho3Imgp();
	$('.info_t').attr("class", "info_t3");
	$('.info15_c2').attr("class", "info15_c");
	$('.info_t4').attr("class", "info_t");
	$('.text').attr("class", "text1");
	$('.keyboard').attr("class", "keyboard1");
	inall.style.backgroundImage = "url(images/open.jpg)";
	//int4.style.backgroundImage = "url(images/top.jpg)";
	var door = json(ebox.GetUiData()).QuJianOrder.EILATTICENO;
	ebox.OpenBox();
	$('#door_id').remove();
	$('body')
			.append(
					'<embed src="mp3/'
							+ door
							+ '号柜门已经打开，请取走您的包裹.mp3" id="door_id" autostart="true" hidden="true" loop="false">');
	$("#door").html(door);
	i = door;
	eboxChangeColor();
	$("#btnOk").click(function() {	
		ebox.closeExpress();
		$('#door_id').remove();
		audio();
		em9.play();
		success();
		tuichu = true;
	});
	timeget();
}
function BoxClosed() {
	$('.info15_c').attr("class", "info15_c2");
	$('.info_t').attr("class", "info_t4");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t2').attr("class", "info_t");
	index1();
}
function timeget() {
	timetxt = $(".time").text();
	if (timetxt == 0) {
		ebox.closeExpress();
		BoxClosed();
		$(".time").text('30');
		clearTimeout("timeget()")
		return false;
	}
	timetxt--
	$(".time").text(timetxt);
	
	if(tuichu){
		$(".time").text('30');
		clearTimeout("timeget()")
		tuichu = false;
	}else{
		setTimeout("timeget()", 1000);
	}
}



function subjs() {
	geturl('false.html');
}
// validfalse
function validfalse() {
	audio();
	$('.info_t').attr("class", "info_t3");
	$('.info_t4').attr("class", "info_t");
	$('.text').attr("class", "text1");
	$('.keyboard').attr("class", "keyboard1");
	$('.info15_c').attr("class", "info15_c2");
	$('.ll1').attr("class", "ll");
	inall.style.backgroundImage = "url(images/validfalse.jpg)";
	//int4.style.backgroundImage = "url(images/top.jpg)";
	em7.stop();
	em8.play();

}
function change() {
	audio();
	$('.ll').attr("class", "ll1");
	$('.info_t').attr("class", "info_t4");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t2').attr("class", "info_t");
	em8.stop();
	index1();
}
$(function() {
	$("#btnOk2").click(function() {
		audio();
		$('.info_t').attr("class", "info_t4");
		$('.info_t3').attr("class", "info_t");
		$('.text1').attr("class", "text");
		$('.keyboard1').attr("class", "keyboard");
		$('.ll').attr("class", "ll1");
		em8.stop();
		quj();
	});
})
// success
function success() {
	$('.info15_c').attr("class", "info15_c2");
	$('.ll2').attr("class", "ll");
	inall.style.backgroundImage = "url(images/success.jpg)";
	//int4.style.backgroundImage = "url(images/top.jpg)";

}
function change1() {
	audio();
	$('.ll').attr("class", "ll2");
	$('.info_t').attr("class", "info_t4");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t2').attr("class", "info_t");
	em9.stop();
	index1();
}
$(function() {
	$("#btnOk2a").click(function() {
		$('.ll').attr("class", "ll2");
		$('.info_t').attr("class", "info_t4");
		$('.info_t3').attr("class", "info_t");
		$('.text1').attr("class", "text");
		$('.keyboard1').attr("class", "keyboard");
		quj();
	});
})

// 快递员登录界面
$('.courierLog').click(function() {
	audio();
	$("#txtUserName1").val("輸入用戶名");
	$("#txtPassword1").val("");
	$('.info5_c').attr("class", "info5_c1");
	$('.info_t').attr("class", "info_t2");
	$('.info_t0').attr("class", "info_t");
	$('.info18_c1').attr("class", "info18_c");
	inall.style.backgroundImage = "url(images/imgs/UI_2_01/allbg.png)";
	fotwe.style.backgroundColor = "#0f1116";
	tail(true);
	em0.play();
	expreslogin();
});
function index5() {
	audio();
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	$('.info18_c').attr("class", "info18_c1");
	em0.stop();
	index1();
	tail(false);
}
function expreslogin() {
	ebox.SetBizCode('EBOX2017');
	ebox.InitIdCard(4, 3);
	function UserValidated(str) {
		var j = json(str);
		if (j.success)
			expreslogin();
		else {
			ms('系統提示','系統不存在該快遞員');
			//alert('系统不存在该快递员');
			index5();
		}
	}
	var uiData = json(ebox.GetUiData());
	var userName = uiData.UserName;
	if (null != userName && '' != userName) {
		$("#txtUserName1").val(userName);

		/*
		 * if(len == 18 || len == 15){ $("#txtUserName").val(userName); }else{
		 * if('1' == userName.substring(0,1)){
		 * $("#txtUserName").val(userName.substring(1)); }else{
		 * $("#txtUserName").val(userName.substring(2)); } }
		 */
	}
	$("#btnLogin").off();
	$("#btnLogin").click(clickBing(function() {
		if ($.trim($("#txtUserName1").val()) == '') {
			ms('系統提示', '請輸入登錄手機');
			return;
		}
		if ($.trim($("#txtPassword1").val()) == '') {
			ms('系統提示', '請輸入登錄密碼');
			return;
		}
		var tel = $("#txtUserName1").val();
		var r = ebox.Login(tel, $("#txtPassword1").val());
		if (!r) {
			ms('系統提示', '用戶名或密碼錯誤');
			$("#txtUserName1").val('輸入用戶名');
			$("#txtPassword1").val('');
		} else {
			var newData = json(ebox.GetUiData());
			var userInfo = newData.UserInfo;
			if (userInfo.userInfo == null) {
				alert('連接服務器超時，請重試');
				window.location.reload();
				// return;
			} else {
				uiData.Method == 3;
				usertype = 4;
				logindex();

			}
		}
	}));
};
// 快递员登录首界面
function logindex() {
	audio();
	$('.info18_c').attr("class", "info18_c1");
	$('.info2_c1').attr("class", "info2_c");
	em0.stop();
	em1.play();
	express();
}
function index4() {
	audio();
	$('.info2_c').attr("class", "info2_c1");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	em1.stop();
	index1();
}
function express() {
	ebox.SetBizCode('EBOX2019');
	var uaCompanyActMoney = 0;

	ebox.startCheckDoor();
	$(this).doTimeout('EBOX2019', 150, function() {
		loadCoureInfo();
	});
	$(window).unload(function() {
		ebox.stopCheckDoor();
	});
}
function loadCoureInfo() {
	var v = json(ebox.GetUiData()).UserInfo;
	if (null == v || undefined == v.userInfo || null == v.userInfo) {
		alert('快递员未授权，请联系运营商');
		audio();
		$('.info2_c').attr("class", "info2_c1");
		$('.info5_c1').attr("class", "info5_c");
		$('.info_t').attr("class", "info_t0");
		$('.info_t2').attr("class", "info_t");
		em1.stop();
		//index1();
	}
	var cnt = json(ebox.openStoreExpress());
	$("#username").html(v.userInfo.uiUserName);
	$("#userphone").html(v.userInfo.uiUserPhone);
	if (v.userAccount == null || '' == v.userAccount) {
		$("#companyActMoney").html('0元');
	} else {
		uaCompanyActMoney = v.userAccount.uaCompanyActMoney;
		$("#companyActMoney").html(v.userAccount.uaCompanyActMoney + "元");
	}
	if (cnt.custExpress >= 0) {
		$("#express").append("<span>" + cnt.custExpress + "</span>");
	}
	if (cnt.overtimeExpress >= 0) {
		$(".po1").html(cnt.overtimeExpress);
		$("#overtime").append("<span>" + cnt.overtimeExpress + "</span>");
	}
	if (cnt.exceptionExpress >= 0) {
		$(".po2").html(cnt.exceptionExpress);
		$("#exception").append("<span>" + cnt.exceptionExpress + "</span>");
	}
	if (parseFloat(cnt.data) > 0) {
		$("#mouthStoreStatus").html("格口还剩" + cnt.data + "个");
	} else {
		$("#mouthStoreStatus").html("格口用完了");
	}
}
function validateCompanyActMoney(){
	if(uaCompanyActMoney <= 0){
		ms('系統提示','快遞員帳戶為0元，不允許存件');
	}else{
		if(validateStoreStatus()){
			stoexp();
		}
	}
}

function  ignor(){
	closediv('post');
	stoexp();
}

function validateStoreStatus(){
	var rst = ebox.validateBoxDoorStatus();
	if ('' == rst) {
		return true;
	} else {
		ms('系統提示', '第【' + rst + '】號門未關，請先關閉<dr/><h3 onclick ="ignor()">忽略</h3> ');
		return false;
	}
}

// 存储快件
function stoexp() {
	audio();
	$("#barcode").val('請掃描包裹定單號');
	$("#phone").val('請輸入收件人手機號碼');
	$("#testphone").val('請輸入收件人手機號碼');
	$("#rephone").val('請再次輸入收件人手機號碼');
	$('.info2_c').attr("class", "info2_c1");
	$('.info6_c1').attr("class", "info6_c");

	em1.stop();
	$("#barcode").focus(function() {
		audio();
		em2.play();
		em3.stop();
		em4.stop();
	});
	$("#phone").focus(function() {
		audio();
		em3.play();
		em2.stop();
		em4.stop();
	});
	$("#rephone").focus(function() {
		audio();
		em4.play();
		em2.stop();
		em3.stop();
	});
	$('#barcode').focus();
	$(".inputcx img").click(function() {
		mr = $(this).parent().find('input').attr('mr');
		$("#testphone").val('');
		$(this).parent().find('input').val(mr);
	});
	ebox.InitBarCodeScannerToRead();
	$("#barcode").focus(function() {
		ebox.InitBarCodeScannerToRead();
		chg = false;
	});
	$('#barcode').bind("blur", function() {
		if ($.trim($(this).val()) != '') {
			onzzszClosed(this);
		}
	});
	$('#barcode').bind("change", function() {
		chg = false;
	});
	// 扫描枪检索到的运单号
	var loginName = '';
	$(this).doTimeout('EBOX2020', lazyTime, function() {
		loadStoreExpressInfo();
	});
}
var uaCompanyActMoney = 0;
function OnCodeScan(code) {
	//alert(code);
	$('#barcode').val(code);
	closediv1('xnszjp');
	onzzszClosed($('#barcode'));
}
function postfo() {
	$("#form1").submit();
}
function alerta(bs, no) {
	var htmls = '';
	switch (bs) {
	case 1:
		htmls = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:350px; height:150px; line-height:60px;"><div class="t_c">請輸入到付金額</div><div class="input7  mt10 l"><input  id="div_expressMoney" onfocus="zzsz(this);" name=""  style="outline:none;text-decoration:none;"></div><div class="bottom l" onclick="submitStoreExpress(\'post\');">確定</div></div></div>';
		break;
	case 2:
		htmls = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:350px; height:150px;padding-top:50px;line-height:60px;"><div class="bottom l" onclick="alerta(1);"  style="outline:none;text-decoration:none;">到付件</div><div class="bottom l" onclick="submitStoreExpress(\'post\');">正常件</div></div></div>';
		break;
	case 3:
		htmls = '<div align="center" class="vipxz" style="background:none;"><div align="center" class="f20 img_2 t_l" style="background:none; width:450px; height:210px; line-height:60px;"><div class="t_c"><embed src="mp3/'
				+ no
				+ '号柜门已经打开，请放入您的包裹.mp3" autostart="true" hidden="true" loop="false"><h1 style="font-size:70px;color:#e98127;">'
				+ no
				+ '</h1>號箱門已打開，投入包裹後請關閉箱門！<p>系統將在 <span class="time2 fyw f_b ">30</span> 秒後返回</p></div><div align="center" class="l emb"><input style="padding-left:60px;" align="left" style="outline:none;text-decoration:none;" name="" type="image" src="images/post/sub.png" onclick="submitStoreExpress(\'post\')"/></div><div class="bottom l emb" onclick="closediv(\'post\')">更换格口</div></div></div>';
		break;
	case 4:
		htmls = '<div align="center" class="vipxz" style="background:none;"><div align="center" class="f20 img_2 t_l" style="background:none; width:450px; height:150px; line-height:60px;"><div align="center" class="t_c">是否黑名單？</div><div align="center"><div class="bottom l"  style="outline:none;text-decoration:none;" onclick="closediv(\'post\'); ms(\'溫馨提示\',\'該包裹請當面派送！\');">是</div><div class="bottom r" onclick="closediv(\'post\');alerta(2);">否</div></div></div></div>';
		break;
	}
	ac = new $.pos({
		title : "&nbsp;",
		width : 700,
		height : 200,
		center : true,
		top : 20,
		left : 30,// center：true 左右上下居中、false自定义top,left。
		url : '',
		form : htmls
	});
	ac.subdiy2();
	//$('.emb').click(function() {
		//emb.stop();
	//})
	if(bs == 3){
		timeget2();
	}
}
ebox.SetBizCode('EBOX2020');
//setInterval("timeget2()", 1000);
var chg = false;
function onzzszClosed(src) {
	var value = $(src).val();
	if ($(src).attr('id') != 'barcode' || $.trim(value) == ''
			|| '請掃描包裹定單號' == value) {
		return;
	}
	if (chg) {
		return;
	}
	var r = ebox.CheckOrderByBarCode($(src).val());
	if (r) {
		chg = true;
		if ('-4' == r) {
			ms('系統提示', '運單號已經使用，請重新輸入');
			$("#barcode").val('');
			return;
		}
		if (parseFloat(r) > 0) {
			$("#phone").val(r);
			$("#testphone").val(r);
			$("#rephone").val(r);
			var rst = json(ebox.queryTimeAndForbidden(r, value));
			if ('-2' == rst) {
				// alert('当前手机客户为黑名单，请线下投递');
				// clearExpressInfo();
				// return;
			}
			if ('-3' == rst) {
				alert('客戶設置了禁投，請線下投遞');
				clearExpressInfo();
				return;
			}
		}
	}
}
function loadStoreExpressInfo() {
	// var cnt = json(ebox.openStoreExpress()).normalCount[0];
	var userinfo = json(ebox.GetUiData()).UserInfo;
	var money = '';
	if (null != userinfo.userAccount && '' != userinfo.userAccount) {
		money = userinfo.userAccount.uaCompanyActMoney;
		uaCompanyActMoney = money;
	}
	loadMouthList();
	loginName = userinfo.userInfo.uiUserName;
	setLoginInfo(loginName, money);
	$('#tbList td').unbind();
	$('#tbList td').click(clickBing(function() {
		camera();
		if (typeof ($(this).attr('moTypeId')) != 'undefined') {
			var txt = $(this).find("span").text();
			if (txt == '0') {
				return;
			}
			validateBarCode($(this).attr('moTypeId'));
			return;
		}
	}));
}
function loadMouthList() {
	// 加载格口类型列表
	var m = ebox.GetFreeMouthList();
	var list = json(m);
	$('#tbList td').html('&nbsp;');
	var map = new Map("mouthArk1");
	for (var i = 0; i < list.length; i++) {
		if (list[i].status == '1') {
			var value = map.get(list[i].momodel);
			if (value == "") {
				map.put(list[i].momodel, list[i].count + "");
			} else {
				map.put(list[i].momodel,
						(parseFloat(value) + parseFloat(list[i].count)) + "");
			}
		}
	}
	// map.showMap();
	var tmp = [];
	for (var i = 0; i < list.length; i++) {
		var ex = true;
		for (var j = 0; j < tmp.length; j++) {
			if (list[i].momodel == tmp[j]) {
				ex = false;
				break;
			}
		}
		if (ex) {
			tmp.push(list[i].momodel);
		}
	}
	for (var i = 0; i < tmp.length; i++) {
		var val = map.get(tmp[i]);
		if ('' != val && '-1' != val) {
			var td = $('#tbList td:eq(' + i + ')');
			if (tmp[i] == "MINI-S")
				s = "迷妳";
			else if (tmp[i] == "S")
				s = "小";
			else if (tmp[i] == "M")
				s = "中";
			else if (tmp[i] == "L")
				s = "大";
			else if (tmp[i] == "XL")
				s = "加大";
			else if (tmp[i] == "XXL")
				s = "超大";
			td.html(s + "┃<span>" + map.get(tmp[i]) + "</span>");
			td.attr('moTypeId', getTypeId(list, tmp[i]));
		} else {

			var td = $('#tbList td:eq(' + i + ')');

			if (tmp[i] == "MINI-S")
				tmp[i] = "迷妳";
			else if (tmp[i] == "S")
				tmp[i] = "小";
			else if (tmp[i] == "M")
				tmp[i] = "中";
			else if (tmp[i] == "L")
				tmp[i] = "大";
			else if (tmp[i] == "XL")
				tmp[i] = "加大";
			else if (tmp[i] == "XXL")
				tmp[i] = "超大";
			td.html(tmp[i] + "┃<span>" + 0 + "</span>");
			td.attr('moTypeId', '');
		}
	}
	map.clearMap();
}
function getTypeId(list, model) {
	for (var i = 0; i < list.length; i++) {
		if (list[i].momodel == model) {
			return list[i].moTypeId
		}
	}
}
function validateBarCode(mouthTypeId) {
	var barcode = $("#barcode").val();
	var phone = $("#testphone").val();
	var rephone = $("#rephone").val();
	if (null == barcode || '' == barcode || '請掃描包裹定單號' == barcode) {
		ms('系統提示', '請填寫快件運單號');
		return;
	}
	if (null == phone || '' == phone || '请請輸入收件人手機號碼' == phone) {
		ms('系統提示', '請填寫收件人手機號');
		return;
	}
	if (null == rephone || '' == rephone || '請再次輸入收件人確認手機號碼' == rephone) {
		ms('系統提示', '請填寫收件人手機號');
		return;
	}
	if (phone != rephone) {
		ms('系統提示', '收件人手機號與確認手機號不符，請重新填寫');
		$("#rephone").val('');
		return;
	}
	var validRst = json(ebox.queryTimeAndForbidden(phone, barcode));
	if ('-2' == validRst) {
		// alert('当前手机客户为黑名单，请线下投递');
		// clearExpressInfo();
		// return;
	}
	if ('-3' == validRst) {
		ms('系統提示', '客戶設置了禁投，請線下投遞');
		clearExpressInfo();
		return;
	}
	camera();
	var rst = ebox.validateBarCode(barcode, phone, mouthTypeId);
	var obj = json(rst);
	if (null == obj && obj.eiBarcode != null) {
		ms('系統提示', '運單號已經錄入，不可重復使用');
		clearExpressInfo();
		return;
	}
	if ('4' == rst) {
		ms('系統提示', '格口類型被使用完，請選擇其他');
		loadMouthList();
		return;
	}
	// alerta(2);
	// submitStoreExpress('post');
	var uidata = json(ebox.GetUiData());
	var JiJianMouthNo = uidata.JiJianMouthNo;
	alerta(3, JiJianMouthNo);
}
function showMouthNo(no) {
	alerta(3, mo);
}
function addHisRow(record) {
	if (null == record || undefined == record) {
		return;
	}
	var barcode = $("#barcode").val();
	// var phone = $("#phone").val();
	var table1 = $('.tableborder');
	// var firstTr = table1.find('tbody>tr:first');
	var row = $("<tr class='f20 f_f fyh img_2'></tr>");
	var td1 = $("<td>" + record.barcode + "</td>");
	row.append(td1);
	var td2 = $("<td>" + record.phone + "</td>");
	row.append(td2);
	var td3 = $("<td>" + record.moNo + "</td>");
	row.append(td3);
	table1.append(row);
}
function reCalcMouth(moTypeId) {
	$("#mouthTypeList tr td").each(function() {
		var a = $($(this).find("a"));
		if (a.attr("id") == moTypeId) {
			var num = (parseFloat(attr2) - 1);
			var attr1 = a.attr("attr1");
			var attr2 = a.attr("attr2");
			if (num == 0) {
				a.attr("attr2", 0);
				a.html(attr1 + "|0");
			} else {
				a.attr("attr2", num);
				a.html(attr1 + "|" + num);
			}
		}
	});
}
function clearExpressInfo() {
	$("#barcode").val('');
	$("#phone").val('');
	$("#testphone").val('');
	$("#rephone").val('');
}
function setBarCode(barcode, phone) {
	$("#barcode").val(barcode);
	if (null != phone && '' != phone) {
		$("#phone").val(phone);
		$("#rephone").val(phone);
		$("#testphone").val(phone);
	}
}
function setLoginInfo(name, money) {
	$("#baseinfo").html('');
	$("#baseinfo").html(
			'姓名: ' + name + '&nbsp;當前可用余額：<span>&nbsp;'
					+ parseFloat(money).toFixed(2) + '元</span>');
}
var submitBoost = false;
function submitStoreExpress(vid) {	
	submitBoost = true
	var loginName = '';
	var money = $("#div_expressMoney").val();
	if (undefined == money || '' == money) {
		money = 0;
	}
	$("." + vid).remove();
	$(".allpost").remove();
	var r = json(ebox.saveStoreExpress(money));
	if (r != '-2') {
		var fee = r.mouthMoney;
		if (fee != null && !isNaN(fee)) {
			var currFee = (parseFloat(uaCompanyActMoney) - parseFloat(fee))
					.toFixed(2);
			uaCompanyActMoney = currFee
			setLoginInfo(loginName, currFee);
		}
		$(".post").remove();
		$(".allpost").remove();
		addHisRow(r);
		loadMouthList();
		$("#barcode").val('');
		$("#phone").val('');
		$("#testphone").val('');
		$("#rephone").val('');
	} else {
		$(".post").remove();
		$(".allpost").remove();
		$("#barcode").val('');
		$("#phone").val('');
		$("#testphone").val('');
		$("#rephone").val('');
		ms('系統提示', '系統存件異常，請取走快件');
	}
}
function timeget2() {
	timetxt = $(".time2").text();
	if (timetxt < 1 && timetxt != '') {
		//alert(Object.prototype.toString.apply(timetxt))
		submitStoreExpress('post');
		timetxt = 30;
	}
	timetxt--;
	if(submitBoost){
		timetxt = 30;
		submitBoost = false;
	}else{
		setTimeout("timeget2()", 1000);
	}	
	$(".time2").text(timetxt);
};

function test1() {
	var phone = $("#phone").val();
	if ($.trim(phone) == '' || '請輸入收件人手機號碼' == phone) {
		$("#phone").val("");
		return;
	}
	if ('***********' != phone) {
		$("#testphone").val(phone);
	}
	$("#phone").val("***********");
}
(function() {
	var midContainer = new Array();
	var mapContainer = new Array();
	var MAPID = 0;
	function Map(mid) {
		var type = typeof (mid);
		if ((type != "string") && (type != "number")) {
			throw "Map id must be a string or number!";
		}
		for (var _c = 0; midContainer[_c]; _c++) {
			if (mid == midContainer[_c])
				throw "You have already created Map : " + mid;
		}
		var identify = MAPID++;
		midContainer[identify] = mid;
		mapContainer[identify] = {};
		mapContainer[identify]["id"] = mid;
		this.id = mid;
		this.prefix = "";
		this.toString = function() {
			return "This is a map object!";
		}
	}

	Map.prototype.getMapId = function() {
		return this.id;
	}
	Map.prototype.getMapIndex = function() {
		var index = -1;
		for (var _i = 0; mapContainer[_i]; _i++) {
			if (this.id == mapContainer[_i]["id"]) {
				index = _i;
			}
		}
		return index;
	}
	Map.prototype.put = function(key, value) {
		if (typeof (key) != "string") {
			throw "key must be a string!";
		}
		if (typeof (value) != "string") {
			throw "value shouldn't be a function!";
		}
		if (this.trimStr(key) == "") {
			throw "key is empty!";
		}
		var index = -1;
		index = this.getMapIndex();
		if (index != -1) {
			key = this.prefix + key;
			mapContainer[index][key] = value;
		}
	}
	Map.prototype.get = function(key) {
		var index = -1;
		index = this.getMapIndex();
		var value = "";
		if (index != -1) {
			var _tV = mapContainer[index];
			key = this.prefix + key;
			value = (_tV.hasOwnProperty(key)) ? _tV[key] : "";
		}
		return value;
	}
	Map.prototype.deleteKey = function(key) {
		var index = -1;
		index = this.getMapIndex();
		key = this.prefix + key;
		var _tV = mapContainer[index];
		if (_tV.hasOwnProperty(key)) {
			delete _tV[key];
		}
	}

	Map.prototype.clearMap = function() {
		var index = -1;
		index = this.getMapIndex();
		var maxId = MAPID - 1;
		if (index <= maxId) {
			for (var t = index; t < maxId; t++) {
				mapContainer[t] = mapContainer[t + 1];
				midContainer[t] = midContainer[t + 1];
			}
			mapContainer[maxId] = null;
			midContainer[maxId] = null;
			this.id = null;
			this.toString = null;
			MAPID--;
		}
	}

	Map.prototype.trimStr = function(str) {
		return str.replace(/(^\s*)|(\s*$)/g, "");
	}
	Map.prototype.isEmpty = function() {
		var index = -1;
		index = this.getMapIndex();
		if (index != -1) {
			for ( var attr in mapContainer[index]) {
				// alert(mapContainer[index][attr]);
				if (attr != "id") {
					return false;
				}
			}
		}
		return true;
	}
	Map.prototype.size = function() {
		return this.MAPID;
	}
	Map.prototype.showMap = function() {
		var index = -1;
		index = this.getMapIndex();
		var str = "";
		if (this.id != null) {
			str = "Map:\t" + this.id + "\n";
			for ( var attr in mapContainer[index]) {
				if (attr != "id") {
					str += attr + ":\t" + mapContainer[index][attr] + "\n";
				}
			}
		} else {
			str = "This Map doesn't exist!";
		}
		alert(str);
		return str;
	}
	window['Map'] = Map;
})();
function test2() {
	var testphone = $.trim($("#testphone").val());
	if (testphone != '') {
		$("#phone").val(testphone);
	}

}
function back() {
	audio();
	$('.info2_c1').attr("class", "info2_c");
	$('.info6_c').attr("class", "info6_c1");
	$('.tableborder .f20').remove();
	
	
	$(".post").empty();	
	$(".allpost").remove();
	
	$("#barcode").val('');
	$("#phone").val('');
	$("#testphone").val('');
	$("#rephone").val('');
	em2.stop();
	em3.stop();
	em4.stop();
	em1.play();
	express();
}
function index13() {
	audio();
	$('.info6_c').attr("class", "info6_c1");
	$('.info5_c1').attr("class", "info5_c");
	$('.info_t').attr("class", "info_t0");
	$('.info_t2').attr("class", "info_t");
	em2.stop();
	em3.stop();
	em4.stop();
	index1();
}
// 取逾期件
function getover() {
	audio();
	$('.info2_c').attr("class", "info2_c1");
	$('.info1_c1').attr("class", "info1_c");
	em1.stop();
	em5.play();
	overexp1();	
}

$('#back1').click(function() {
	back2();
});