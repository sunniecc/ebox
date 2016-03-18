// index.html
/**
*编号为index
*一下代码是index.html的代码
*改页面里面有1个jqruey默认方法,
*0个方法
*/
function index1(){
	//终止一个setTimeout设置的时间，这里是终止60s返回主界面的定时方法
	clearTimeout(timer);
	//悬浮动态图片，slider.js
	$('.flexslider').flexslider({
		animation: "slide",
		start: function(slider){
		  $('body').removeClass('loading');
		}
	});
	//doTimeout实现事件延迟触发功能
	$(this).doTimeout('EBOX2001', 200, function() {
		//初始化
		ebox.ReInit();
	});
}
$(function(){
	index1();
})
//查件身份证
function selectid(){
	$('.info_t').attr("class","info_t0");
	$('.info_t1').attr("class","info_t");
	$('.info5_c').attr("class","info5_c1");
	$('.info18_c1').attr("class","info18_c");
}
//管理员登录身份证页面
$('.img0').click(function(){
	selectid();
	admin();
})
function admin(){
	ebox.ReInit();
	ebox.SetBizCode('EBOX2033');  
    ebox.InitIdCard(3,4);
	function UserValidated(str)
	{
		var j = json(str);
		if(j.success)
			password();
		else
			//ms('系統提示','管理员身份证不存在');
			alert('管理员身份证不存在');
			index1();
	}
}
function index3(){
	$('.info_t0').attr("class","info_t");
	$('.info_t').attr("class","info_t1");
	$('.info5_c1').attr("class","info5_c");
	$('.info18_c').attr("class","info18_c1");
	index1();
}
//取件登录页面
$('.img1').click(function(){
	$('.info_t').attr("class","info_t0");
	$('.info_t1').attr("class","info_t");
	$('.info8_c1').attr("class","info8_c");
	$('.btn1').attr("class","btn");
	$('.info5_c').attr("class","info5_c1");
	$(function(){
		$(".input3 img").click(function(){
			var mr=$(this).parent().find('input').attr('mr');
			$(this).parent().find('input').val(mr);
		});
	});
	$(function () {
            $("#btnOk").click(function () {
				if($.trim($('#txt_tel').val())=='請輸入手機號码'||$.trim($('#txt_tel').val())==''){
					ms('系統提示',"請輸入手機號");
					return;
				}
				if($.trim($('#txt_yzm').val())=='請輸入驗證碼'||$.trim($('#txt_yzm').val())==''){
					ms('系統提示',"請輸入驗證碼");
					return;
				}
                submitQuJIan();
            });
			$("#openSannerPort").click(function(){
				ebox.InitBarCodeScannerToRead();
			});
        });
		function OnCodeScan(code)
		{
			var data = json(ebox.validateQRCode(code));
			if(null == data || data == '{}'){
				ms('系統提示','讀取二維碼錯誤，請更換手機號及驗證碼再試');
				return;
			}
			$('#txt_tel').val(data.eiTakeUserPhone);
			$('#txt_yzm').val(data.eiValidateCode);
			submitQuJIan();
		}
		
		function submitQuJIan(){
			var r = json(ebox.CustQuJian($('#txt_tel').val(), $('#txt_yzm').val()));
			if (r.success) {
				if(r.status == '3'){
					if (r.type == 1010) {
						quj();
					}else
					{
						alert('走支付流程');
					}
				}else{
					if (r.type == 1010) {
						ms('系統提示','您的快件已逾期，请交纳逾期费用后再取件');
						//geturl('取件格口打开.html');
						excepfee();
					}else
					{
						alert('走支付流程');
					}
				}
				
			}else {
				ms('信息提示', '驗證失敗，請重試');
			}
		}
        function toUrl(i) {
            if (i == true) {
                var r = eval('(' + ebox.QuJian($('#txt_tel').val(), $('#txt_yzm').val()) + ')');
                if (r.success)
                    proto();
                else {
                    alert(r.msg);
                }
            }
            else
                quj();
        }

        function BoxClosed(id) {
            alert(id);
        }	
})
$("#bot13").click(function(){
	$('.info_t').attr("class","info_t1");
	$('.info_t0').attr("class","info_t");
	$('.info8_c').attr("class","info8_c1");
	$('.btn').attr("class","btn1");
	$('.info5_c1').attr("class","info5_c");
	index1();
})
//逾期快件交费
function excepfee(){
	$('.info_t').attr("class","info_t1");
	$('.info8_c').attr("class","info8_c1");
	$('.btn').attr("class","btn1");
	$('.info17_c4').attr("class","info17_c");
	excepfee1();
}
function excepfee1(){
	ebox.SetBizCode('EBOX2048');
	$('#txtNeedPay').val(ebox.getPaymentMoney());
    ebox.StartCoinMachine();
	function OnCodeScan(code){
		
	}

	function OnTouchCoin(cnt){
		$("#paymentMoney").val(cnt);
		if(cnt == $("#txtNeedPay").val()){
			var rst = json(ebox.paymentOvertimeExpress(cnt));
			if(rst.success){
				quj2();
			}
		}
	}
}
//格口打开-c
function mouthopen(){
	$('.info1_c').attr("class","info1_c3");
	$('.info15_c3').attr("class","info15_c");
	window.setInterval("timegetge()",1000);
var uiData = json(ebox.GetUiData());
var usertype = uiData.UserType;
//不要打开ebox.SetBizCode('EBOX2022');
$(window).load(function() {
	//var v = ebox.openBox();
	var v = json(ebox.GetUiData());
	//alert(v);
	$("#gridNum").text(v.JiJianMouthNo);
});
}
function finish(){
ebox.finishGetExpress();
if(usertype == 4){
		$('.info2_c1').attr("class","info2_c");
		$('.info15_c3').attr("class","info15_c");
		express1();
	}else if(usertype == 3){	
		$('.info3_c1').attr("class","info3_c");
		$('.info15_c3').attr("class","info15_c");
		adm1();
	}else{
		geturl('index.html');
	}
}
function timegetge(){
	timetxt=$(".timege").text();
	if(timetxt==0){
		finish();
		location.href = "index.html";
		return false;
	}
	timetxt--
	$(".timege").text(timetxt);
}
//取件格口打开页面
function quj(){
	$('.info_t').attr("class","info_t1");
	$('.info8_c').attr("class","info8_c1");
	$('.btn').attr("class","btn1");	
	$('.info15_c1').attr("class","info15_c");
	quj1();
}
function quj2(){
	$('.info17_c').attr("class","info17_c4");
	$('.info15_c1').attr("class","info15_c");
	quj1();
}
function quj1(){
	var door = json(ebox.GetUiData()).QuJianOrder.EILATTICENO;
	ebox.OpenBox();
	var w;
    $("#door").html(door);
    $("#btnOk1").click(function () {
        ebox.closeExpress();
        geturl('index.html');
    }); 
    function BoxClosed() {
		geturl('index.html');
    }  
    setInterval("timeget1()", 1000);

        $('#subjs').click(function() {
            var a = new $.pos({
                title: "请选择拒收原因",
                width: 500, center: true, top: 20, left: 30,
                url: '取件4-拒收重新放入格口.html',
                form: [
					 { "name": '不是我的快件', 'id': '2' },
					 { "name": '快件破损', 'id': '1' },
					 { "name": '快件不符', 'id': '3' },
					 { "name": '其他', 'id': '4' }
					 ]
            });
            a.message1();
        });
}

    	function timeget1() {
            timetxt1 = $(".time1").text();
            if (timetxt1 == 0) {
				ebox.closeExpress();
				geturl('index.html');
                return false;
            }
            timetxt--;
            $(".time1").text(timetxt);
        }
//寄件身份证页面
$('.img2').click(function(){
	ebox.ReInit();	
	selectid();
	ebox.SetBizCode('EBOX2006');
	    ebox.InitIdCard(5,1);
	function UserValidated(str)
	{
		var j = json(str);
		if(j.success)
			password();
		else if(j.rst == '-6'){
			alert('该用户已经注册');
			index2();
		}else
			proto2(); 
	}

	function toUrl()
	{
		if(confirm('是否首次使用？')) 
			geturl('协议.html'); 
		else 
			geturl('完善寄件信息.html');
	}	
})
//存件身份证页面
$('.img3').click(function(){
	ebox.ReInit();
	selectid();
	ebox.SetBizCode('EBOX2017');  
	ebox.InitIdCard(4,3);
	function UserValidated(str)
	{
		var j = json(str);
		if(j.success)
			password();
		else{
			//ms('系統提示','系统不存在该快递员');
			alert('系统不存在该快递员');
			index2();
		}
	}
})
function index2(){
	$('.info_t0').attr("class","info_t");
	$('.info_t').attr("class","info_t1");
	$('.info5_c1').attr("class","info5_c");
	$('.info18_c').attr("class","info18_c1");
	index1();
}
//查询页面
$('.img4').click(function(){
	$('.info_t').attr("class","info_t0");
	$('.info_t1').attr("class","info_t");
	$('.info7_c1').attr("class","info7_c");
	$('.button1').attr("class","button");
	$('.info5_c').attr("class","info5_c1");
	$("#search").click(function(){
		var barCodeVal 	 = $("#barCode").val();
		var telephoneVal = $("#telephone").val();
		closediv1('xnszjp');
		if(barCodeVal==''&&telephoneVal==''){
			ms('系統提示','请输入查询条件');
			return ;
		}
		barCodeVal=$.trim(barCodeVal);
		telephoneVal=$.trim(telephoneVal);
		var list= json( ebox.orderCheckExpress(barCodeVal,telephoneVal)) ;
		$('#.tableborder1 tr:gt(0)').remove()
		if(list && list.length == 0){
			$("#expressList").removeAttr("style");
			$('.tableborder1 tr:eq(0)').after('<tr class="f20 f_f fyh img_2" ><td colspan="6" height="70" align="left" class="p_l15">无查询结果</td></tr>');
			
		}else{
			if(list.length > 5){
				$("#expressList").attr("style","height:400px;overflow-y:auto;overflow-x:hidden;");	
			}else{
				$("#expressList").removeAttr("style");
			}
			for(var i=0;i<list.length;i++)
			 {
				var order = list[i];
				var tr = '<tr class="f20 f_f fyh img_2"  >';
				tr +=' <td height="70" align="left" class="p_l15">'+ (order.barNo?order.barNo:'') +'</td>';
				tr +='  <td>'+order.takeUserPhone1+'</td>';
				tr +=' <td>'+order.status+'</td>';
				tr +=' <td>'+order.storeTime+'</td>';
				tr +=' <td align="center">'+order.storeUserName+'</td>';
				tr +=' <td align="center" >'+ order.storeUserPhone+'</td>';
				tr +=' </tr>';
				 $('#tbList1 tr:eq(0)').after(tr);
			 }
	 
		}
		})	
})
function index(){
	$('.info_t').attr("class","info_t1");
	$('.info_t0').attr("class","info_t");
	$('.info7_c').attr("class","info7_c1");
	$('.button').attr("class","button1");
	$('.info5_c1').attr("class","info5_c");
	index1();
}
$(".button1").click(function(){
	index();
})
//会员中心登录页面
$('.img5').click(function(){
	ebox.ReInit();
	selectid();
	ebox.SetBizCode('EBOX2027'); 
    ebox.InitIdCard(5,2);
	function UserValidated(str)
	{
		var j = json(str);
		if(j.success)
			password();
		else if(j.rst == '-6'){
			alert('该用户已经注册');
			index4();
		}else
			proto2(); 
	}	
})
function index4(){
	$('.info_t').attr("class","info_t1");
	$('.info_t0').attr("class","info_t");
	$('.info5_c1').attr("class","info5_c");
	$('.info18_c').attr("class","info18_c1");
	index1();
}
$("#bot10").click(function(){
	index4();
})
//用户名密码登录页
function password(){
	$('.infot1').attr("class","infot");
	$('.info18_c').attr("class","info18_c1");
	$('.info18_c2').attr("class","info18_c");
    $("#txtUserName").val('输入用户手机');
    $("#txtPassword").val('');
	var uiData = json(ebox.GetUiData());
    a=uiData.Method;
            var userName = uiData.UserName;
			if(null != userName && '' != userName){
				$("#txtUserName").val(userName);
				/*
				if(len == 18 || len == 15){
					$("#txtUserName").val(userName);
				}else{
					if('1' == userName.substring(0,1)){
						$("#txtUserName").val(userName.substring(1));
					}else{
						$("#txtUserName").val(userName.substring(2));
					}
				}*/
			}
            $("#btnLogin").click(function () {
				var tel = $("#txtUserName").val();
				if($.trim(tel) == ''){
					ms('系統提示', '請輸入登錄手機');
					return;
				}
				if($.trim($("#txtPassword").attr("value")) == ''){
					ms('系統提示', '请输入登录密码');
					return;
				}
                var r = ebox.Login(tel, $("#txtPassword").val());
                if (!r) {
                    ms('系統提示', '用戶名或密碼錯誤');
                } else {
					var newData = json(ebox.GetUiData());
					var userInfo =newData.UserInfo;
					if(userInfo.userInfo == null){
						alert('连接服务器超时，请重试');
						window.location.reload();
						//return;
					}else{
						if (a == 1) {
							perexp();
							perexp1();
						}
						else if(a==3)
						{
							express();
						}
						else if(a==4)
						{
							adm();
						}  else {
							member();
						}
					}
                }
            });
}
$("#bot11").click(function(){
	password();
})
$("#bot12").click(function(){
	index5();
})
function index5(){
	$('.infot').attr("class","infot1");
	$('.info_t').attr("class","info_t1");
	$('.info_t0').attr("class","info_t");
	$('.info5_c1').attr("class","info5_c");
	$('.info18_c').attr("class","info18_c2");
	index1();
}
function index6(){
	$('.info_t').attr("class","info_t1");
	$('.info_t0').attr("class","info_t");
	$('.info5_c1').attr("class","info5_c");
	$('.info2_c').attr("class","info2_c1");
	index1();
}
function index7(){
	$('.info_t').attr("class","info_t1");
	$('.info_t0').attr("class","info_t");
	$('.info5_c1').attr("class","info5_c");
	$('.info3_c').attr("class","info3_c1");
	index1();
}
function express(){
	$('.infot').attr("class","infot1");
	$('.info3_c').attr("class","info3_c1");
	$('.info20_c').attr("class","info20_c1");
	$('.info10_c').attr("class","info10_c1");
	$('.info2_c1').attr("class","info2_c");
	$('.info18_c').attr("class","info18_c2");
	express1();
}
function express1(){
	ebox.SetBizCode('EBOX2019');
	ebox.startCheckDoor();
	$(this).doTimeout('EBOX2019', 150, function() {
		loadCoureInfo();
	});
	function loadCoureInfo(){
	var v = json(ebox.GetUiData()).UserInfo;
	if(null == v || undefined == v.userInfo || null == v.userInfo){
		alert('快递员未授权，请联系运营商');
		index6();
	}
	var cnt = json(ebox.openStoreExpress());
	$("#username").html(v.userInfo.uiUserName);
	$("#userphone").html(v.userInfo.uiUserPhone);
	if(v.userAccount == null || '' == v.userAccount){
		$("#companyActMoney").html('0元');
	}else{
		uaCompanyActMoney = v.userAccount.uaCompanyActMoney;
		$("#companyActMoney").html(v.userAccount.uaCompanyActMoney+"元");
	}
	if(cnt.custExpress >= 0){
		$("#express").append("<span>"+cnt.custExpress+"</span>");
	}
	if(cnt.overtimeExpress >= 0){
		$(".po1").html(cnt.overtimeExpress);
		$("#overtime").append("<span>"+cnt.overtimeExpress+"</span>");
	}
	if(cnt.exceptionExpress >= 0){
		$(".po2").html(cnt.exceptionExpress);
		$("#exception").append("<span>"+cnt.exceptionExpress+"</span>");
	}
	if(parseFloat(cnt.data) >0){
		$("#mouthStoreStatus").html("格口还剩"+cnt.data+"个");
	}else{
		$("#mouthStoreStatus").html("格口用完了");
	}
}
validateStoreStatus();
}
function validateStoreStatus(){
	var rst = ebox.validateBoxDoorStatus();
	if('' == rst){
		return true;
	}else{
		ms('系統提示','第【'+msi+'】号门未关，请先关闭');
		return false;
	}
}
function ima(){
	if(uaCompanyActMoney <= 0){
		ms('系統提示','快递员帐户为0元，不允许存件');
	}else{
		if(validateStoreStatus()){
			store();
		}
	}
};
//存储包裹
function store(){
	$('.info2_c').attr("class","info2_c1");
	$('.info6_c1').attr("class","info6_c");
	$('#barcode').focus();
	$(".inputcx img").click(function(){
		mr=$(this).parent().find('input').attr('mr');
		$("#testphone").val('');
		$(this).parent().find('input').val(mr);
	});
	ebox.InitBarCodeScannerToRead();
	$("#barcode").focus(function(){
		ebox.InitBarCodeScannerToRead();
		chg = false;
	});
	$('#barcode').bind("blur",function(){
		if($.trim($(this).val()) != ''){
			onzzszClosed(this);
		}
	});
	$('#barcode').bind("change",function(){
		chg = false;
	});
//扫描枪检索到的运单号
var loginName = '';
	$(this).doTimeout('EBOX2020', lazyTime, function() {
		loadStoreExpressInfo();
	});

$('#back').click(function(){
	$('.info2_c1').attr("class","info2_c");
	$('.info6_c').attr("class","info6_c1");
	express1();
})
$('#backok').click(function(){
	$('.info2_c1').attr("class","info2_c");
	$('.info6_c').attr("class","info6_c1");
	express1();
})
}
var uaCompanyActMoney = 0;
function OnCodeScan(code)
{
	$('#barcode').val(code);
	closediv1('xnszjp');
	onzzszClosed($('#barcode'));
}
function postfo(){
	$("#form1").submit();
}
function alerta(bs,no){
	var htmls = '';
	switch(bs){
	case 1:	
htmls='<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:350px; height:150px; line-height:60px;"><div class="t_c">請輸入到付金額</div><div class="input7  mt10 l"><input  id="div_expressMoney" onfocus="zzsz(this);" name=""  style="outline:none;text-decoration:none;"></div><div class="bottom l" onclick="submitStoreExpress(\'post\');">確定</div></div></div>';
		break;
		case 2:
htmls='<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:350px; height:150px;padding-top:50px;line-height:60px;"><div class="bottom l" onclick="alerta(1);"  style="outline:none;text-decoration:none;">到付件</div><div class="bottom l" onclick="submitStoreExpress(\'post\');">正常件</div></div></div>';
		break;
		case 3:	
htmls='<div align="center" class="vipxz" style="background:none;"><div align="center" class="f20 img_2 t_l" style="background:none; width:450px; height:210px; line-height:60px;"><div class="t_c"><embed src="" autostart="true" hidden="true" loop="false"><h1 style="font-size:70px;color:#e98127;">'+no+'</h1>號箱門已打開，投入包裹後請關閉箱門！<p>系統將在 <span class="time2 fyw f_b ">30</span> 秒後返回</p></div><div align="center" class="l"><input style="padding-left:60px;" align="left" style="outline:none;text-decoration:none;" name="" type="image" src="images/post/sub.png" onclick="submitStoreExpress(\'post\')"/></div><div class="bottom l" onclick="closediv(\'post\')">取消</div></div></div>';
		break;
		case 4:	
htmls='<div align="center" class="vipxz" style="background:none;"><div align="center" class="f20 img_2 t_l" style="background:none; width:450px; height:150px; line-height:60px;"><div align="center" class="t_c">是否黑名單？</div><div align="center"><div class="bottom l"  style="outline:none;text-decoration:none;" onclick="closediv(\'post\'); ms(\'溫馨提示\',\'該包裹請當面派送！\');">是</div><div class="bottom r" onclick="closediv(\'post\');alerta(2);">否</div></div></div></div>';
		break;
	}
	ac = new $.pos({
		title: "&nbsp;",
		width:700,height:200,center:true,top:20,left:30,//center：true 左右上下居中、false自定义top,left。
		url:'',
		form:htmls
		});
	ac.subdiy2();
}
ebox.SetBizCode('EBOX2020');
setInterval("timeget2()", 1000);

var chg = false;
function onzzszClosed(src)
{
	var value = $(src).val();
	if($(src).attr('id')!= 'barcode' || $.trim(value)=='' || '請掃描包裹定單號'==value){
		return ;
	}
	if(chg){
		return;
	}
	var r = ebox.CheckOrderByBarCode($(src).val());
	if(r)
	{
		chg = true;
		if('-4' == r){
			ms('系統提示','運單號已經使用，請重新輸入');
			$("#barcode").val('');
			return;
		}
		if(parseFloat(r) > 0){
			$("#phone").val(r);
			$("#testphone").val(r);
			$("#rephone").val(r);
			var rst = json(ebox.queryTimeAndForbidden(r,value));
			if('-2' == rst){
				//alert('当前手机客户为黑名单，请线下投递');
				//clearExpressInfo();
				//return;
			}
			if('-3' == rst){
				alert('客戶設置了禁投，請線下投遞');
				clearExpressInfo();
				return;
			}
		}
	}
}
function loadStoreExpressInfo(){	
	//var cnt = json(ebox.openStoreExpress()).normalCount[0];
	var userinfo = json(ebox.GetUiData()).UserInfo;
	var money = '';
	if(null != userinfo.userAccount && '' !=userinfo.userAccount){
		money = userinfo.userAccount.uaCompanyActMoney;
		uaCompanyActMoney = money;
	}
	loadMouthList();
	loginName=userinfo.userInfo.uiUserName;
	setLoginInfo(loginName,money);
	$('#tbList td').click(function(){
		if(typeof($(this).attr('moTypeId'))!='undefined'){
			var txt = $(this).find("span").text();
			if(txt == '0'){
				return;
			}
			validateBarCode($(this).attr('moTypeId'));
			return;
		}
	});
}
function loadMouthList()
{
	//加载格口类型列表
	var m = ebox.GetFreeMouthList();
	var list= json(m);
	$('#tbList td').html('&nbsp;');
	var map = new Map("mouthArk1");
	for(var i =0;i<list.length;i++){
		if(list[i].status == '1'){
			var value = map.get(list[i].momodel);
			if(value == ""){
				map.put(list[i].momodel,list[i].count+"");
			}else{
				map.put(list[i].momodel,(parseFloat(value)+parseFloat(list[i].count))+"");
			}
		}
	}
	//map.showMap();
	var tmp = [];
	for(var i=0;i<list.length;i++)
	{
		var ex = true;
		for(var j=0;j<tmp.length;j++){
			if(list[i].momodel == tmp[j]){
				ex = false;
				break;
			}
		}
		if(ex){
			tmp.push(list[i].momodel);
		}
	}
	for(var i=0;i<tmp.length;i++)
	{
		var val = map.get(tmp[i]);
		if('' != val && '-1' != val){
			var td=  $('#tbList td:eq('+i+')');
			if(tmp[i]=="MINI-S")
s="迷妳";
else if(tmp[i]=="S")
s="小";
else if(tmp[i]=="M")
s="中";
else if(tmp[i]=="L")
s="大";
else if(tmp[i]=="XL")
s="加大";
else if(tmp[i]=="XXL")
s="超大";
			td.html(s+"┃<span>"+map.get(tmp[i])+"</span>");
			td.attr('moTypeId',getTypeId(list,tmp[i]));
		}else{
			
			var td=  $('#tbList td:eq('+i+')');

if(tmp[i]=="MINI-S")
tmp[i]="迷妳";
else if(tmp[i]=="S")
tmp[i]="小";
else if(tmp[i]=="M")
tmp[i]="中";
else if(tmp[i]=="L")
tmp[i]="大";
else if(tmp[i]=="XL")
tmp[i]="加大";
else if(tmp[i]=="XXL")
tmp[i]="超大";
			td.html(tmp[i]+"┃<span>"+0+"</span>");
			td.attr('moTypeId','');
		}
	}
	map.clearMap();
}
function getTypeId(list,model){
	for(var i=0;i<list.length;i++){
		if(list[i].momodel == model){
			return list[i].moTypeId
		}
	}
}
function validateBarCode(mouthTypeId){
	var barcode = $("#barcode").val();
	var phone = $("#testphone").val();
	var rephone = $("#rephone").val();
	if(null == barcode || '' == barcode || '請掃描包裹定單號'==barcode){
		ms('系統提示','請填寫快件運單號');
		return;
	}
	if(null == phone || ''==phone || '请請輸入收件人手機號碼' == phone){
		ms('系統提示','請填寫收件人手機號');
		return;
	}
	if(null == rephone || ''==rephone || '請再次輸入收件人確認手機號碼'==rephone){
		ms('系統提示','請填寫收件人手機號');
		return;
	}
	if(phone != rephone){
		ms('系統提示','收件人手機號與確認手機號不符，請重新填寫');
		$("#rephone").val('');
		return;
	}
	var validRst = json(ebox.queryTimeAndForbidden(phone,barcode));
	if('-2' == validRst){
		//alert('当前手机客户为黑名单，请线下投递');
		//clearExpressInfo();
		//return;
	}
	if('-3' == validRst){
		ms('系統提示','客戶設置了禁投，請線下投遞');
		clearExpressInfo();
		return;
	}
	var rst = ebox.validateBarCode(barcode,phone,mouthTypeId);
	var obj = json(rst);
	if(null == obj && obj.eiBarcode != null){
		ms('系統提示','運單號已經錄入，不可重復使用');
		clearExpressInfo();
		return;
	}
	if('4' == rst){
		ms('系統提示','格口類型被使用完，請選擇其他');
		loadMouthList();
		return;
	}
	//alerta(2);
	//submitStoreExpress('post');
	var uidata = json(ebox.GetUiData());
    var JiJianMouthNo =uidata.JiJianMouthNo;
	alerta(3,JiJianMouthNo);
}
function showMouthNo(no){
	alerta(3,mo);
}
function addHisRow(record){
	if(null == record || undefined == record){
		return;
	}
	var barcode = $("#barcode").val();
	//var phone = $("#phone").val();
	var table1 = $('.tableborder0'); 
	//var firstTr = table1.find('tbody>tr:first'); 
	var row = $("<tr class='f20 f_f fyh img_2'></tr>"); 
	var td1 = $("<td>"+record.barcode+"</td>"); 
	row.append(td1); 
	var td2 = $("<td>"+record.phone+"</td>"); 
	row.append(td2); 
	var td3 = $("<td>"+record.moNo+"</td>"); 
	row.append(td3); 
	table1.append(row); 
}
function reCalcMouth(moTypeId){
	$("#mouthTypeList tr td").each(function(){
		var a = $($(this).find("a"));
		if(a.attr("id")==moTypeId){
			var num = (parseFloat(attr2) - 1);
			var attr1 = a.attr("attr1");
			var attr2 = a.attr("attr2");
			if( num== 0){
				a.attr("attr2",0);
				a.html(attr1+"|0");
			}else{
				a.attr("attr2",num);
				a.html(attr1+"|"+num);
			}
		}
	});
}
function clearExpressInfo(){
	$("#barcode").val('');
	$("#phone").val('');
	$("#testphone").val('');
	$("#rephone").val('');
}
function setBarCode(barcode,phone){
	$("#barcode").val(barcode);
	if(null != phone && ''!=phone){
		$("#phone").val(phone);
		$("#rephone").val(phone);
		$("#testphone").val(phone);
	}
}
function setLoginInfo(name,money){
	$("#baseinfo").html('');
	$("#baseinfo").html('姓名: '+name+'&nbsp;當前可用余額：<span>&nbsp;'+parseFloat(money).toFixed(2)+'元</span>');
}
function submitStoreExpress(vid){
	var loginName = '';
	var money = $("#div_expressMoney").val();
	if(undefined == money || '' == money){
		money = 0;
	}
	$("." + vid).remove();
    $(".allpost").remove();
	var r = json(ebox.saveStoreExpress(money));
	if(r != '-2'){
		var fee = r.mouthMoney;
		if(fee != null && !isNaN(fee)){
			var currFee = (parseFloat(uaCompanyActMoney)-parseFloat(fee)).toFixed(2);
			uaCompanyActMoney = currFee
			setLoginInfo(loginName,currFee);
		}
		$(".post").remove();
		$(".allpost").remove();
		addHisRow(r);
		loadMouthList();
		$("#barcode").val('');
		$("#phone").val('');
		$("#testphone").val('');
		$("#rephone").val('');
	}else{
		$(".post").remove();
		$(".allpost").remove();
		$("#barcode").val('');
		$("#phone").val('');
		$("#testphone").val('');
		$("#rephone").val('');
		ms('系統提示','系統存件異常，請取走快件');
	}
}
        function timeget2() {
            timetxt = $(".time2").text();
            
            timetxt--;
            if (timetxt == 0) {
            	submitStoreExpress('post');
                return false;
            }
            $(".time2").text(timetxt);

        };
        function test1(){
	var phone = $("#phone").val();
	if($.trim(phone) == '' || '請輸入收件人手機號碼'==phone){
		$("#phone").val("");
		return;
	}
	if('***********' != phone){
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
       if ( typeof (key) != "string") {  
           throw "key must be a string!";  
       }  
       if ( typeof (value) != "string") {  
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
            for (var attr in mapContainer[index]) {  
                //alert(mapContainer[index][attr]);  
                if (attr != "id") {  
                    return false;  
                }  
            }  
        }  
        return true;  
    } 
	Map.prototype.size = function(){
		return this.MAPID;
	}
    Map.prototype.showMap = function() {  
        var index = -1;  
        index = this.getMapIndex();  
        var str = "";  
        if (this.id != null) {  
            str = "Map:\t" + this.id + "\n";  
            for (var attr in mapContainer[index]) {  
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
function test2(){
	var testphone = $.trim($("#testphone").val());
	if(testphone != ''){
		$("#phone").val(testphone);
	}
	
}
//管理员登录
function adm(){
	$('.infot').attr("class","infot1");
	$('.info3_c1').attr("class","info3_c");
	$('.info2_c').attr("class","info2_c1");
	$('.info20_c').attr("class","info20_c1");
	$('.info10_c').attr("class","info10_c1");
	$('.info18_c').attr("class","info18_c2");
	adm1();
}
function adm1(){
	ebox.SetBizCode('EBOX2035');
	$(this).doTimeout('EBOX2035', lazyTime, function() {
		loadAdminInfo();
	});
function loadAdminInfo(){
	var v = json(ebox.GetUiData()).UserInfo;
	var authz = v.terminalFunction;
	if(null == authz || authz == undefined ){
		ms('系統提示','系統未授權');
		return;
	}
	$("#adminname").text(v.userInfo.uiLoginName);
	$("#adminphone").text(v.userInfo.uiUserPhone);
	$("#adminunit").text(v.userInfo.uiDeptName);
	for(var i=0;i<authz.length;i++){
		$("#ebox"+authz[i].tfFuncNo).show();
	}
	var cnt = json(ebox.openStoreExpress());
	if(cnt.custExpress > 0){
		$("#ebox5").append("<span>"+cnt.custExpress+"</span>");
	}
	if(cnt.overtimeExpress > 0){
		$("#ebox3").append("<span>"+cnt.overtimeExpress+"</span>");
	}
	if(cnt.exceptionExpress > 0){
		$("#ebox4").append("<span>"+cnt.exceptionExpress+"</span>");
	}
}
}
function projectExit(){
	if(confirm('確認退出系統？')){
		ebox.Exit();
	}
}
//取寄件
function sender(){	
	$('.info2_c').attr("class","info2_c1");
	$('.info1_c1').attr("class","info1_c");
	sender1();
  ebox.SetBizCode('EBOX2021');
	sender2();
}
function sender3(){
	$('.info3_c').attr("class","info3_c1");
	$('.info1_c1').attr("class","info1_c");
	sender1();
    ebox.SetBizCode('EBOX2021');
	sender2();
}
function sender1(){
	$(".che").live("click",function(){
		if($(this).find('input').attr("checked")){
			$(this).find("img").attr("src","images/info/checkbox1.png");
			$(this).find("input").attr("checked",false);
			$(this).find("input").val('0');
		}else{
			$(this).find("img").attr("src","images/info/checkbox2.png");
			$(this).find("input").attr("checked","true");
			$(this).find("input").val('1');
		}
	});
	ebox.SetBizCode('EBOX2021');
	var uiData = json(ebox.GetUiData());
	var usertype = uiData.UserType;
}
	function getSelectItem2(){
		var idArr=[],lockArr=[];
		$(".tableborder2 tbody tr").each(function(){
			$(this).find("input[type=checkbox]").each(function(){
				if($(this).attr("checked")){
					idArr.push($(this).attr("bizId"));
					lockArr.push($(this).attr("lockNo"));
				}	
			});
		});
		openBox2(idArr,lockArr);
	}
function getAllItem2(){
	var idArr=[],lockArr=[];
	$(".tableborder2 tbody tr").each(function(){
		$(this).find("input[type=checkbox]").each(function(){
			idArr.push($(this).attr("bizId"));
			lockArr.push($(this).attr("lockNo"));
		});
	});
	openBox2(idArr,lockArr);
}

function openBox2(idArr,lockArr){
	if(null == idArr || idArr.length==0){
		ms('系統提示', '請選擇寄件項');
		return;
	}
	var monos = ebox.setOpenBoxAttr(idArr);
	geturl('mouthopen()?monos='+monos);
}
$('#back3').click(function(){
	if(usertype == 4){	
		$('.info2_c1').attr("class","info2_c");
		$('.info1_c').attr("class","info1_c1");
		express1();
	}else if(usertype == 3){	
		$('.info3_c1').attr("class","info3_c");
		$('.info1_c').attr("class","info1_c1");
		adm1();
	}else{
		geturl('index.html');
	}
});
function sender2(){
	var expressList = json(ebox.loadUserExpress());
	var bodylist = '<tr class="f20 f_f fyh img_2">';
	for(var i=0;i<expressList.length;i++){
		bodylist += '<tr class="f20 f_f fyh img_2">'
		bodylist += '<td height="50" class="p_l15 che">'
		bodylist += '<input name="id" type="checkbox" value="" bizId="'+expressList[i].eiId+'" lockNo="'+(expressList[i].moLockNo?expressList[i].moLockNo:'')+'" /><img src="images/info/checkbox1.png" />'+ (expressList[i].eiStoreUserName?expressList[i].eiStoreUserName:'')+'</td>';
		bodylist += '<td>'+ (expressList[i].eiStoreUserPhone?expressList[i].eiStoreUserPhone:'')+'</td>';
		bodylist += '<td>'+(expressList[i].eiStoreTime?expressList[i].eiStoreTime:'')+'</td>';
		bodylist += '<td>'+(expressList[i].eiLatticeNo?expressList[i].eiLatticeNo:'')+'</td>';
		bodylist += '<td>'+(expressList[i].eiCityName?expressList[i].eiCityName:'')+'</td>';
		bodylist += '<td>'+(expressList[i].eiPaymentMoney?expressList[i].eiPaymentMoney:'')+'</td>';
		bodylist+='</tr>';
	}
	$('.tableborder2 tr:gt(0)').remove();
	$(".tableborder2 tr:eq(0)").after(bodylist);
}
/**
*编号：取逾期件
*以下代码为取逾期件.html
*共有2个jQuery默认代码
*5个方法
*/
//取逾期件
function overexp(){	
	$('.info2_c').attr("class","info2_c1");
	$('.info1_c2').attr("class","info1_c");
	overexp1();
}
function overexp2(){	
	$('.info3_c').attr("class","info3_c1");
	$('.info1_c2').attr("class","info1_c");
	overexp1();
}
function loadOvertimeExpressList(){
	var rst = ebox.loadOvertimeExpress();
	var expressList = json(rst);
	var bodylist = '<tr class="f20 f_f fyh img_2">';
	for(var i=0;i<expressList.length;i++){
		bodylist += '<tr class="f20 f_f fyh img_2">'
		bodylist += '<td height="50" class="p_l15 che">'
		bodylist += '<input name="id" type="checkbox" value="" bizId="'+expressList[i].eiId+'" lockNo="'+expressList[i].moLockNo+'" /><img src="images/info/checkbox1.png" />'+expressList[i].eiBarcode+'</td>';
		bodylist += '<td>'+expressList[i].eiStoreUserPhone+'</td>';
		bodylist += '<td>'+expressList[i].eiStoreTime+'</td>';
		bodylist += '<td>'+expressList[i].eiLatticeNo+'</td>';
		bodylist += '<td>'+expressList[i].overTimeDay+'</td>';
		bodylist+='</tr>';
	}
	$('.tableborder3 tr:gt(0)').remove();
	$(".tableborder3 tr:eq(0)").after(bodylist);
}

function overexp1(){
	//点击一个单选框，如果这个单选框已经被选中，则取消选中，如果这个单选框未被选中，则选中这个
	$(".che").live("click",function(){
		if($(this).find('input').attr("checked")){
			$(this).find("img").attr("src","images/info/checkbox1.png");
			$(this).find("input").attr("checked",false);
			}else{
		$(this).find("img").attr("src","images/info/checkbox2.png");
		$(this).find("input").attr("checked","checked");
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
function getSelectItem3(){
	var idArr=[],lockArr=[];
	$(".tableborder3 tbody tr").each(function(){
		$(this).find("input[type=checkbox]").each(function(){
			if($(this).attr("checked")){
				idArr.push($(this).attr("bizId"));
				lockArr.push($(this).attr("lockNo"));
			}	
		});
	});
	openBox3(idArr,lockArr);
}
function getAllItem3(){
	var idArr=[],lockArr=[];
	$(".tableborder3 tbody tr").each(function(){
		$(this).find("input[type=checkbox]").each(function(){
			idArr.push($(this).attr("bizId"));
			lockArr.push($(this).attr("lockNo"));
		});
	});
	openBox3(idArr,lockArr);
}

function openBox3(idArr,lockArr){
	if(null == idArr || idArr.length==0){
		ms('系統提示', '請選擇寄件項');
		return;
	}
	ebox.setOpenBoxAttr(idArr);
	mouthopen();
}
$('#back1').click(function(){
	if(usertype == 4){	
		$('.info2_c1').attr("class","info2_c");
		$('.info1_c').attr("class","info1_c2");
		express1();
	}else if(usertype == 3){	
		$('.info3_c1').attr("class","info3_c");
		$('.info1_c').attr("class","info1_c2");
		adm1();
	}else{
		geturl('index.html');
	}
});
//取异常件
function excepexp(){
	$('.info2_c').attr("class","info2_c1");
	$('.info1_c3').attr("class","info1_c");
	excepexp1();
}
function excepexp2(){
	$('.info3_c').attr("class","info3_c1");
	$('.info1_c3').attr("class","info1_c");
	excepexp1();
}
function excepexp1(){
	$(".che").live("click",function(){
		if($(this).find('input').attr("checked")){
			$(this).find("img").attr("src","images/info/checkbox1.png");
			$(this).find("input").attr("checked",false);
			}else{
		$(this).find("img").attr("src","images/info/checkbox2.png");
		$(this).find("input").attr("checked","checked");
			}
	});

ebox.SetBizCode('EBOX2025');
var uiData = json(ebox.GetUiData());
var usertype = uiData.UserType;
	$(this).doTimeout('EBOX2025', lazyTime, function() {
		loadExceptionExpressList();
	});
$('#back2').click(function(){
	if(usertype == 4){	
		$('.info2_c1').attr("class","info2_c");
		$('.info1_c').attr("class","info1_c3");
		express1();
	}else if(usertype == 3){	
		$('.info3_c1').attr("class","info3_c");
		$('.info1_c').attr("class","info1_c3");
		adm1();
	}else{
		geturl('index.html');
	}
});
}

function openBox4(idArr,lockArr){
	if(null == idArr || idArr.length==0){
		ms('系統提示', '請選擇寄件項');
		return;
	}
	ebox.setOpenBoxAttr(idArr);
	mouthopen();
}
function getSelectItem4(){
	var idArr=[],lockArr=[];
	$(".tableborder4 tbody tr").each(function(){
		$(this).find("input[type=checkbox]").each(function(){
			if($(this).attr("checked")){
				idArr.push($(this).attr("bizId"));
				lockArr.push($(this).attr("lockNo"));
			}	
		});
	});
	openBox4(idArr,lockArr);
}
function getAllItem4(){
	var idArr=[],lockArr=[];
	$(".tableborder4 tbody tr").each(function(){
		$(this).find("input[type=checkbox]").each(function(){
			idArr.push($(this).attr("bizId"));
			lockArr.push($(this).attr("lockNo"));
		});
	});
	openBox4(idArr,lockArr);
}
function loadExceptionExpressList(){
	var expressList = json(ebox.loadExceptionExpress());
	var bodylist = '<tr class="f20 f_f fyh img_2">';
	for(var i=0;i<expressList.length;i++){
		var remark = '';
		if(expressList[i].eoRemark == '1'){
			 remark = '快件破损';
		}else if(expressList[i].eoRemark == '2'){
			 remark = '不是我的快件';
		}else if(expressList[i].eoRemark == '3'){
			 remark = '快件不符';
		}else{
			remark = '其他';
		}
		bodylist += '<tr class="f20 f_f fyh img_2">'
		bodylist += '<td height="50" class="p_l15 che">'
		bodylist += '<input name="id" type="checkbox" value="" bizId="'+expressList[i].eiId+'" lockNo="'+expressList[i].moLockNo+'" /><img src="images/info/checkbox1.png" />'+expressList[i].eiBarcode+'</td>';
		bodylist += '<td>'+expressList[i].eiStoreUserPhone+'</td>';
		bodylist += '<td>'+expressList[i].eiStoreTime+'</td>';
		bodylist += '<td>'+expressList[i].eiLatticeNo+'</td>';
		bodylist += '<td>'+remark+'</td>';
		bodylist+='</tr>';
	}
	$('.tableborder4 tr:gt(0)').remove();
	$(".tableborder4 tr:eq(0)").after(bodylist);
}

//完善寄件信息
function perexp(){
	$('.infot').attr("class","infot1");
	$('.info3_c').attr("class","info3_c1");
	$('.info2_c').attr("class","info2_c1");
	$('.info20_c').attr("class","info20_c1");
	$('.info10_c1').attr("class","info10_c");
	$('.info18_c').attr("class","info18_c2");
}
function perexp2(){
	$('.info10_c1').attr("class","info10_c");
	$('.info12_c').attr("class","info12_c1");
}

var cacheAddress = '';
function perexp1(){
	var t = null;
	ebox.SetBizCode('EBOX2008');
	ebox.StartCamera();
	t = setInterval(function() { 
		timeget4();
	}, 3200);
	$(this).doTimeout('EBOX2008', lazyTime, function() {
		loadCustInfo();
	});
	var timetxt = 0;
	function timeget4(){
	timetxt++;
	if(timetxt==4){
		clearInterval(t);
		ebox.CloseCamera();
		return false;
	}
	
	ebox.Snapshot();
}
function zzsz1(sthis) {
    var htmlsz = '<div class="xnszjp1" id="xnszjp"><ul><li class="s">1</li><li class="s">2</li><li class="s">3</li><li class="s">4</li><li class="s">5</li><li class="s">6</li><li class="s">7</li><li class="s">8</li><li class="s">9</li><li class="s">*</li><li class="s">0</li><li class="s">#</li><li  onclick="closediv1(\'xnszjp1\')"><img src="images/post/a1.png"  />&nbsp;</li><li class="wc" onclick="closediv1(\'xnszjp1\')">Enter</li><li class="j">del</li></ul></div>';
    $(".info_all_01").append(htmlsz);

    var objoffset = $(sthis).offset();
    var objoffset1 = $(sthis).parent().offset();

    $(".xnszjp1").css("left", objoffset1.left-160);
    $(".xnszjp1").css("top", objoffset.top + $(sthis).height() + 11);

    $(".xnszjp1 .s").click(function () {
        $(sthis).val($(sthis).val() + $(this).text());
    });
	$(".xnszjp1 li").mousedown(function() {
		$(this).addClass("ss");
	});
	$(".xnszjp1 li").mouseup(function(){
		$(this).removeClass("ss");
	});
	window['zzszSrc'] = sthis;
	
    $(".xnszjp1 .j").click(function () {
        var s = $(sthis).val();
        s = s.substring(0, s.length - 1);
        $(sthis).val(s);
    });
}
function loadCustInfo(){
   var uidata = json(ebox.GetUiData());
   var pboxconfig= json(ebox.GetPBoxConfig());
   var userInfo =uidata.UserInfo;

   $('#tdUserName').html(userInfo.userInfo.ciUserName+ ' 电话：'+userInfo.userInfo.ciUserPhone);
   $('#pboxAddress').html(pboxconfig.PBADDRESS);
  
	//var str='';
	var addrList = userInfo.userAddress;
	if(null != addrList && undefined != addrList){
		cacheAddress = addrList;
		if(addrList.length > 2){
			$("#addressList").attr("style","height:140px;overflow-y:auto;overflow-x:hidden;");	
		}else{
			$("#addressList").removeAttr("style");
		}
		for(var i=0;i<addrList.length;i++){
			var str = '';
			str+=' <tr onclick="setSelectedAddress('+i+')">';
			str+='<td width="19%" height="65" align="right" valign="middle"  class="img_2"><input name="add"   class="hide"type="radio" value="2" /><img src="images/info/row.png"  class="cur xzadd" />&nbsp;预设地址'+(i +1)+'：</td>';
			str+='<td width="3%" align="left">&nbsp;</td>';
			str+='<td width="78%" align="left" style="line-height:30px;">收件人： '+addrList[i].adRecipientName+'， 电话：'+addrList[i].adRecipientPhone+'&nbsp;&nbsp;地址：'+addrList[i].adAddress+'</td>';
			str+='</tr>';
			$('#tbAddress tr:eq('+i+')').after(str);
	   }
	}
   var cache = ebox.GetJiJianInfo();
   if(null != cache){
	
   }
	$('input[name="add"]:checked').parent().find('img').attr('src','images/info/row1.png');
	$(".delin").click(function(){
	mr=$(this).parent().find('input').attr('mr');
		$(this).parent().find('input').val(mr);
	});
	$(".xzadd").click(function(){
			$(".xzadd").attr('src','images/info/row.png');
			$(this).attr('src','images/info/row1.png');
			$(this).parent().find('input').attr('checked','checked');
	})
	
function get_cookie(name) {
    if (document.cookie.length > 0) {
        offset = document.cookie.indexOf(name + "=")
        if (offset >= 0) {
            offset += search.length
            end = document.cookie.indexOf(";", offset)
            if (end == -1) end=document.cookie.length
            return unescape(document.cookie.substring(offset, end))
       }
   }
   return null
}
if (get_cookie("backgroundcolor")!="") document.bgColor=get_cookie("backgroundcolor")

}
function select1()
	{
	$("#s_province").html("");
	
		var provList= json(ebox.GetProviceList());

		for (var i = 0; i < provList.length; i++) {
			$("#s_province").append("<option value=" + provList[i].PROVINCEID + ">" + provList[i].PROVNAME + "</option>");
		}
		select2();
	}
	
	select1();
	$('#s_province').bind("change", select2);
	$('#s_city').bind("change", select3);
	
	$('#btnOk2').click(function(){
		if($.trim($("#txt_tel1").val()) == ''){
			ms('系統提示','货物信息不能为空');
			return;
		}
		if($.trim($("#txtsl1").val()) == ''){
			ms('系統提示','收件人姓名不能为空');
			return;
		}
		if($.trim($("#jiJianTelTxt").val()) == ''){
			ms('系統提示','收件人电话不能为空');
			return;
		}
		if($.trim($("#txtsl3").val()) == ''){
			ms('系統提示','收件人地址不能为空');
			return;
		}
		
		var proNo =$('#s_province :selected').val();
		var proName= $('#s_province :selected').text();
		var cityNo = $('#s_city :selected').val();
		var cityName= $('#s_city :selected').text();
		var conNo = $('#s_county :selected').val();
		var conName= $('#s_county :selected').text();
		
		var pkgName = $.trim($("#txt_tel1").val());
		var recName = $.trim($("#txtsl1").val());
		var recPhone = $.trim($("#jiJianTelTxt").val());
		var recAddr = $.trim($("#txtsl3").val());
		
		ebox.SaveJiJianInfo(proNo,proName,cityNo,cityName,conNo,conName,pkgName,recName,recPhone,recAddr);
		selectexp();
	});
}

function select2() {
	$("#s_city").html("");
	
	var cityList = json(ebox.GetCityList($('#s_province').attr("value")));
	for (var i = 0; i < cityList.length; i++) {
		$("#s_city").append("<option value=" + cityList[i].CITYNO + ">" + cityList[i].CITYNAME + "</option>");
	}
	select3();
};
function select3() {
	$("#s_county").html("");
	var countyList = json(ebox.GetCountyList($('#s_city').attr("value")));
   
	for (var i = 0; i < countyList.length; i++) {
		$("#s_county").append("<option value=" + countyList[i].COID + ">" + countyList[i].CONAME + "</option>");
	}
};
function setcolor() {
      choice=document.back.colar.selectedIndex
      new_colar=document.back.colar.options[choice].value
      document.bgColor= new_colar
      document.cookie= "backgroundcolor=" + new_colar
}
function setSelectedAddress(index)
{
	var addr = cacheAddress[index];
	$('#s_province').attr("value",addr.adProNo);
	select2();
	$("#s_city").attr("value",addr.adCityNo);
	select3();
	$("#s_county").attr("value",addr.adCoNo);
	$("#txtsl3").val(addr.adAddress);
	$("#txtsl1").val(addr.adRecipientName);
	$("#jiJianTelTxt").val(addr.adRecipientPhone);
}
 
//选择快递公司
function selectexp(){
	$('.info10_c').attr("class","info10_c1");
	$('.info12_c1').attr("class","info12_c");
	selectexp1();
}
function selectexp2(){
	$('.info13_c').attr("class","info13_c1");
	$('.info12_c1').attr("class","info12_c");
	selectexp1();
}
function selectexp1(){
		$(this).doTimeout('EBOX2009', 100, function() {
			loadExpressCompanyList();
		});
	ebox.SetBizCode('EBOX2009');
	function loadExpressCompanyList(){
		var configList = json(ebox.GetLogisticsCompanyConfig());
		$('#cmpList').html('');
		for (var i = 0; i < configList.length; i++) {
			var config = configList[i];
			$('#cmpList').append('<li> <div style="text-align:center;line-height:150px;background-color:#D38E55; width:200px;height:150px; font-size: 36px;color:White;" onclick="expweigh()" >'+ config.LCLCMAINNAME + '</div> </li>');
			CmpID=config.LCLCMAINID;
		}
	}
}
//会员中心
function member(){
	$('.infot').attr("class","infot1");
	$('.info3_c').attr("class","info3_c1");
	$('.info2_c').attr("class","info2_c1");
	$('.info10_c').attr("class","info10_c1");
	$('.info20_c1').attr("class","info20_c");
	$('.info18_c').attr("class","info18_c2");
	member1();
}
function member2(){
	$('.info20_c1').attr("class","info20_c");
	$('.info15_c').attr("class","info15_c2");
	member1();
}
function member1(){
	ebox.SetBizCode('EBOX2029');
var memConfig = -1;
var userid=-1;
	$(".getf td").click(function(){
		memConfig = $(this).attr("id");
		var thistxt=$(this);
		var thislen=$(".getf td").index(thistxt);
		formhtml=viphtml(thislen);
		a = new $.pos({
			title: thistxt.find('.title').text(),
			width:700,center:true,top:20,left:30,//center：true 左右上下居中、false自定义top,left。
			url:thistxt.attr('url'),
			form:formhtml
			});
		a.subdiy();
		$('.content').css('height', $('#formTable').height());
	});
	var uidata = json(ebox.GetUiData());
    var userInfo =uidata.UserInfo;
	$("#userName").html(userInfo.userInfo.ciUserName);
	$("#userPhone").html(userInfo.userInfo.ciUserPhone);
	userid = userInfo.userInfo.ciId;
	if(null != userInfo.userAccount){
		$("#userAccount").html(userInfo.userAccount.uaCurrActMoney+'元');
	}else{
		$("#userAccount").html('0元');
	}
	if('1' == userInfo.userInfo.ciUserProxyFlag){
		var show = '<div class="r t" value="1">自取&gt;</div>';
		$("#7008").find("div[value=1]").html(show);
		setPageValue('7008','1','','');
	}else if('2' == userInfo.userInfo.ciUserProxyFlag){
		var show = '<div class="r t" value="2">由['+userInfo.userInfo.ciProxyUserPhone+']带取&gt;</div>';
		$("#7008").find("div[value=1]").html(show);
		setPageValue('7008','2',userInfo.userInfo.ciProxyUserPhone,'');
	}
	
	var memberConfigList = userInfo.userinfoConfig;
	for(var i=0;i<memberConfigList.length;i++){
		var key = memberConfigList[i].ucSysKey;
		var value = memberConfigList[i].ucSysValue
		if('7007' == key){
			//禁投设定
			if('1' == value){
				var show = '<div class="r t" value="'+value+'">正常投递&gt;</div>';
				$("#7007").find("div[value=1]").html(show);
			}else if('2' == value){
				var show = '<div class="r t" value="'+value+'">全部不允许投递到派宝箱&gt;</div>';
				$("#7007").find("div[value=1]").html(show);
			}else if('3' == value){
				var show = '<div class="r t" value="'+value+'">['+memberConfigList[i].ucValueOne+']运单号不允许投递&gt;</div>';
				$("#7007").find("div[value=1]").html(show);
			}
			setPageValue(key,value,memberConfigList[i].ucValueOne,'');
		}/**else if('7008' == key){
			//处理方式设定
			if('1' == value){
				var show = '<div class="r t" value="'+value+'">自取&gt;</div>';
				$("#7008").find("div[value=1]").html(show);
			}else if('2' == value){
				var show = '<div class="r t" value="'+value+'">由['+memberConfigList[i].ucValueOne+']带取&gt;</div>';
				$("#7008").find("div[value=1]").html(show);
			}
		}*/else if('7009' == key){
			//通知方式设定
			if('1' == value){
				var show = '<div class="r t" value="'+value+'">短信通知&gt;</div>';
				$("#7009").find("div[value=1]").html(show);
			}else if('2' == value){
				var show = '<div class="r t" value="'+value+'">由['+memberConfigList[i].ucValueOne+']邮件通知&gt;</div>';
				$("#7009").find("div[value=1]").html(show);
			}else if('1,2' == value){
				var show = '<div class="r t" value="'+value+'">短信通知与邮件通知&gt;</div>';
				$("#7009").find("div[value=1]").html(show);
			}
			setPageValue('7009',value,memberConfigList[i].ucValueOne,'');
		}else if('7010' == key){
			//短信发送方式设定
			if('1' == value){
				var show = '<div class="r t" value="'+value+'">只发本人&gt;</div>';
				$("#7010").find("div[value=1]").html(show);
			}else if('2' == value){
				var show = '<div class="r t" value="'+value+'">只发代领人&gt;</div>';
				$("#7010").find("div[value=1]").html(show);
			}else if('3' == value){
				var show = '<div class="r t" value="'+value+'">本人+代领人&gt;</div>';
				$("#7010").find("div[value=1]").html(show);
			}
			setPageValue('7010',value,'','');
		}else if('7011' == key){
			//允许投递时间设定
			if('1' == value){
				var show = '<div class="r t" value="'+value+'">全时段&gt;</div>';
				$("#7011").find("div[value=1]").html(show);
			}else if('2' == value){
				var show = '<div class="r t" value="'+value+'">周一至周五&gt;</div>';
				$("#7011").find("div[value=1]").html(show);
			}else if('3' == value){
				var show = '<div class="r t" value="'+value+'">周六周日&gt;</div>';
				$("#7011").find("div[value=1]").html(show);
			}else if('4' == value){
				var show = '<div class="r t" value="'+value+'">自定义['+memberConfigList[i].ucValueOne+','+memberConfigList[i].ucValueTwo+']&gt;</div>';
				$("#7011").find("div[value=1]").html(show);
			}
			setPageValue('7011',value,memberConfigList[i].ucValueOne,memberConfigList[i].ucValueTwo);
		}
	}
}
function setPageValue(key,value,value1,value2){
	if('7007' == key){
		if('1' == value){
			jintouSet = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" id="toudiSet1" type="radio" value="1" class="hide" checked="checked"/><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;正常投递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet2" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;全部不允许投递到快递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet3" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;本单不允许投递<br /><div class="input2"><input onfocus="zzsz(this,true);" name="barCode" id="barCode" ><div id="xnszjp-contain"></div></div></div></div>';
		}else if('2' == value){
			jintouSet = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" id="toudiSet1" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;正常投递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet2" type="radio" value="2" class="hide" checked="checked"/><img src="images/info/row1.png" id="2" class="cur xzadd" />&nbsp;全部不允许投递到快递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet3" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;本单不允许投递<br /><div class="input2"><input onfocus="zzsz(this,true);" name="barCode" id="barCode" ><div id="xnszjp-contain"></div></div></div></div>';
		}else if('3' == value){
			jintouSet = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" id="toudiSet1" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;正常投递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet2" type="radio" value="2" class="hide" checked="checked"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;全部不允许投递到快递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet3" type="radio" value="3" class="hide" /><img src="images/info/row1.png" id="3" class="cur xzadd" />&nbsp;本单不允许投递<br /><div class="input2"><input onfocus="zzsz(this,true);" name="barCode" id="barCode" value='+value1+'><div id="xnszjp-contain"></div></div></div></div>';
		}
	}
	if('7008' == key){
		if('1' == value){
			chulifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2" style="background:none; line-height:60px;"><input name="name" type="radio" value="1" class="hide" checked="checked" /><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;自取&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;代领&nbsp;&nbsp;&nbsp;&nbsp;<div class="ma dt" style="width:450px;height:50px;margin:50px auto 50px auto; "><div class="l">代领人手机号码：</div><div class="input2"><input name="" id="phone" onfocus="zzsz(this, true);" type="text" value=""  mr="請輸入手機號码"  onfocus="if(this.value==\'請輸入手機號码\')this.value=\'\';"  /><div id="xnszjp-contain"></div></div></div></div></div>';
		}else if('2' == value){
			chulifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2" style="background:none; line-height:60px;"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;自取&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide" checked="checked" /><img src="images/info/row1.png" id="2" class="cur xzadd" />&nbsp;代领&nbsp;&nbsp;&nbsp;&nbsp;<div class="ma dt" style="width:450px;height:50px;margin:50px auto 50px auto; "><div class="l">代领人手机号码：</div><div class="input2"><input name="" id="phone" onfocus="zzsz(this, true);" type="text" value="'+value1+'"  mr="請輸入手機號码"  onfocus="if(this.value==\'請輸入手機號码\')this.value=\'\';"  /><div id="xnszjp-contain"></div></div></div></div></div>';
		}
	}
	if('7009' == key){
		if('1' == value){
			tongzhifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l i2tts" style="background:none; line-height:40px;width:400px;margin-top:30px;"><div><input name="noticeMode" type="checkbox" value="1" class="dei"  checked="checked"/><img src="images/info/checkbox2.png" id="1"  class="c xzadd1" />&nbsp;&nbsp;&nbsp;&nbsp;短信通知</div><br /><div><input name="noticeMode" type="checkbox"  value="2" class="dei" /><img src="images/info/checkbox1.png" class="c xzadd1"    id="2"/>&nbsp;&nbsp;&nbsp;&nbsp;邮件通知   <div id="emailh" class="abs"></div><input name="email" id="eamil"  onBlur="test(\'eamil\',\'emailh\');" onfocus="test(\'eamil\',\'emailh\');"   /><div id="xnszjp-contain"></div></div> </div><br /><br /></div></div></div>';
		}else if('2' == value){
			tongzhifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l i2tts" style="background:none; line-height:40px;width:400px;margin-top:30px;"><div><input name="noticeMode" type="checkbox" value="1" class="dei" /><img src="images/info/checkbox1.png" id="1"  class="c xzadd1" />&nbsp;&nbsp;&nbsp;&nbsp;短信通知</div><br /><div><input name="noticeMode" type="checkbox"  value="2" class="dei" checked="checked"/><img src="images/info/checkbox2.png"  id="2" class="c xzadd1"  />&nbsp;&nbsp;&nbsp;&nbsp;邮件通知   <div id="emailh" class="abs"></div><input name="email" id="eamil"  onBlur="test(\'eamil\',\'emailh\');" onfocus="test(\'eamil\',\'emailh\');"   /><div id="xnszjp-contain"></div></div> </div><br /><br /></div></div></div>';
		}else if('1,2' == value){
			tongzhifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l i2tts" style="background:none; line-height:40px;width:400px;margin-top:30px;"><div><input name="noticeMode" type="checkbox" value="1" class="dei" checked="checked" /><img src="images/info/checkbox2.png" id="1"  class="c xzadd1" />&nbsp;&nbsp;&nbsp;&nbsp;短信通知</div><br /><div><input name="noticeMode" type="checkbox"  value="2" class="dei" checked="checked"/><img src="images/info/checkbox2.png"  id="2" class="c xzadd1"  />&nbsp;&nbsp;&nbsp;&nbsp;邮件通知   <div id="emailh" class="abs"></div><input name="email" id="eamil" value="'+value1+'" onBlur="test(\'eamil\',\'emailh\');" onfocus="test(\'eamil\',\'emailh\');"   /><div id="xnszjp-contain"></div></div> </div><br /><br /></div></div></div>';
		}
	}
	if('7010' == key){
		if('1' == value){
			smsfasongfangsi = '<div class="vipxz"><div class="kk f20 img_2"><input name="name" type="radio" value="1" class="hide" checked="checked"/><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;只发本人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;只发本人只发代领人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;本人+代领人</div><div class="viptxt"><strong>温馨提示：</strong><br />如您选择“<strong>本人+代领人</strong>”同时发送，系统将收取额外短信费用：0.1元/条，请确保您账户有足够余额。</div></div>';
		}else if('2' == value){
			smsfasongfangsi = '<div class="vipxz"><div class="kk f20 img_2"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;只发本人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide" checked="checked"/><img src="images/info/row1.png" id="2" class="cur xzadd" />&nbsp;只发本人只发代领人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;本人+代领人</div><div class="viptxt"><strong>温馨提示：</strong><br />如您选择“<strong>本人+代领人</strong>”同时发送，系统将收取额外短信费用：0.1元/条，请确保您账户有足够余额。</div></div>';
		}else if('3' == value){
			smsfasongfangsi = '<div class="vipxz"><div class="kk f20 img_2"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;只发本人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;只发本人只发代领人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="3" class="hide" checked="checked"/><img src="images/info/row1.png" id="3" class="cur xzadd" />&nbsp;本人+代领人</div><div class="viptxt"><strong>温馨提示：</strong><br />如您选择“<strong>本人+代领人</strong>”同时发送，系统将收取额外短信费用：0.1元/条，请确保您账户有足够余额。</div></div>';
		}
	}
	if('7011' == key){
		if('1' == value){
			toudishijian = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" type="radio" value="1" class="hide" checked="checked"/><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;全时段&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;周一至周五&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;周六周日&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="4" class="hide" /><img src="images/info/row.png" id="4" class="cur xzadd" />&nbsp;自定义<br /><div class="l">自：</div><div class="input2 l"><input onClick="zzsz(this,true)" name="valueOne" id="valueOne"></div><div class="clear"></div><div class="l">至：</div><div class="input2 l"><input  onClick="zzsz(this,true)" name="valueTwo" id="valueTwo" ><div id="xnszjp-contain"></div></div></div></div>';
		}else if('2' == value){
			toudishijian = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;全时段&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide" checked="checked"/><img src="images/info/row1.png" id="2" class="cur xzadd" />&nbsp;周一至周五&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;周六周日&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="4" class="hide" /><img src="images/info/row.png" id="4" class="cur xzadd" />&nbsp;自定义<br /><div class="l">自：</div><div class="input2 l"><input onClick="zzsz(this,true)" name="valueOne" id="valueOne"></div><div class="clear"></div><div class="l">至：</div><div class="input2 l"><input  onClick="zzsz(this,true)" name="valueTwo" id="valueTwo" ><div id="xnszjp-contain"></div></div></div></div>';
		}else if('3' == value){
			toudishijian = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;全时段&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;周一至周五&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" type="radio" value="3" class="hide"  checked="checked"/><img src="images/info/row1.png" id="3" class="cur xzadd" />&nbsp;周六周日&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="4" class="hide" /><img src="images/info/row.png" id="4" class="cur xzadd" />&nbsp;自定义<br /><div class="l">自：</div><div class="input2 l"><input onClick="zzsz(this,true)" name="valueOne" id="valueOne"></div><div class="clear"></div><div class="l">至：</div><div class="input2 l"><input  onClick="zzsz(this,true)" name="valueTwo" id="valueTwo" ><div id="xnszjp-contain"></div></div></div></div>';
		}else if('4' == value){
			toudishijian = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row.png" id="1" class="cur xzadd" />&nbsp;全时段&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;周一至周五&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;周六周日&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="4" class="hide" /><img src="images/info/row1.png" id="4" class="cur xzadd" />&nbsp;自定义<br /><div class="l">自：</div><div class="input2 l"><input onClick="zzsz(this,true)" name="valueOne" id="valueOne" value='+value1+'></div><div class="clear"></div><div class="l">至：</div><div class="input2 l"><input  onClick="zzsz(this,true)" name="valueTwo" id="valueTwo" value='+value2+'><div id="xnszjp-contain"></div></div></div></div>';
		}
	}
}
function clearValue(obj){
	if(this.value='請輸入手機號码'){
		this.value='';
	}
}
var jintouSet = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" id="toudiSet1" type="radio" value="1" class="hide" checked="checked"/><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;正常投递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet2" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;全部不允许投递到快递&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" id="toudiSet3" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;本单不允许投递<br /><div class="input2"><input onfocus="zzsz(this,true);" name="barCode" id="barCode" ><div id="xnszjp-contain"></div></div></div></div>';
var chulifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2" style="background:none; line-height:60px;"><input name="name" type="radio" value="1" class="hide" checked="checked" /><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;自取&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;代领&nbsp;&nbsp;&nbsp;&nbsp;<div class="ma dt" style="width:450px;height:50px;margin:50px auto 50px auto; "><div class="l">代领人手机号码：</div><div class="input2"><input name="" id="phone" onfocus="zzsz(this,true);clearValue(this);" type="text" value=""  mr="請輸入手機號码" /><div id="xnszjp-contain"></div></div></div></div></div>';
var tongzhifangsi = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l i2tts" style="background:none; line-height:40px;width:400px;margin-top:30px;"><div><input name="noticeMode" type="checkbox" value="1" class="dei" /><img src="images/info/checkbox1.png" id="1"  class="c xzadd" />&nbsp;&nbsp;&nbsp;&nbsp;短信通知</div><br /><div><input name="noticeMode" type="checkbox"  value="2" class="dei" /><img src="images/info/checkbox1.png" class="c xzadd"  />&nbsp;&nbsp;&nbsp;&nbsp;邮件通知   <div id="emailh" class="abs"></div><input name="email" id="eamil"  onBlur="test(\'eamil\',\'emailh\');" onfocus="test(\'eamil\',\'emailh\');"   /><div id="xnszjp-contain"></div></div> </div><br /><br /></div></div></div>';
var smsfasongfangsi = '<div class="vipxz"><div class="kk f20 img_2"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;只发本人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;只发本人只发代领人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;本人+代领人</div><div class="viptxt"><strong>温馨提示：</strong><br />如您选择“<strong>本人+代领人</strong>”同时发送，系统将收取额外短信费用：0.1元/条，请确保您账户有足够余额。</div></div>';
var toudishijian = '<div class="vipxz" style="background:none;"><div class="f20 img_2 t_l" style="background:none; width:340px; height:300px; line-height:60px;"><input name="name" type="radio" value="1" class="hide"/><img src="images/info/row1.png" id="1" class="cur xzadd" />&nbsp;全时段&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="2" class="hide"/><img src="images/info/row.png" id="2" class="cur xzadd" />&nbsp;周一至周五&nbsp;&nbsp;&nbsp;&nbsp;<br /><input name="name" type="radio" value="3" class="hide" /><img src="images/info/row.png" id="3" class="cur xzadd" />&nbsp;周六周日&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="4" class="hide" /><img src="images/info/row.png" id="4" class="cur xzadd" />&nbsp;自定义<br /><div class="l">自：</div><div class="input2 l"><input onClick="zzsz(this,true)" name="valueOne" id="valueOne"></div><div class="clear"></div><div class="l">至：</div><div class="input2 l"><input  onClick="zzsz(this,true)" name="valueTwo" id="valueTwo" ><div id="xnszjp-contain"></div></div></div></div>';
function viphtml(thisindex){
	switch(thisindex){
	case 0:	
	return jintouSet;
	break;
	case 1:
	return chulifangsi;
	break;
	case 2:
	return tongzhifangsi;
	break;
	case 3:	
	return smsfasongfangsi;
	break;
	case 4:	
	return toudishijian;
	break;
	default:
//<div class="vipxz">
//<div class="kk f20 img_2"><input name="name" type="radio" value="1" class="hide" checked="checked" /><img src="images/info/row.png" class="cur xzadd" />&nbsp;只发本人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="1" class="hide" checked="checked" /><img src="images/info/row.png" class="cur xzadd" />&nbsp;只发本人只发代领人&nbsp;&nbsp;&nbsp;&nbsp;<input name="name" type="radio" value="1" class="hide" checked="checked" /><img src="images/info/row.png" class="cur xzadd" />&nbsp;本人+代领人
//</div>
//</div>
	}
}
function closediv(method){
	if('submit' == method){
		if('7007' == memConfig){
			$(".xzadd").parent().find("input[type=radio]").each(
			function(i){
				if($(this).attr("checked") == 'checked'){
					var key =$(this).val();
					var barcode = '';
					if('3' == key){
						barcode = $("#barCode").val();
						$("#7007").find("div[value=1]").html('<div class="r t" value="'+key+'">['+barcode+']运单号不允许投递&gt;</div>');
					}else if('2' == key){
						$("#7007").find("div[value=1]").html('<div class="r t" value="'+key+'">全部不允许投递到派宝箱&gt;</div>');
					}else{
						$("#7007").find("div[value=1]").html('<div class="r t" value="'+key+'">正常投递&gt;</div>');
					}
					ebox.memberConfig(memConfig,key,barcode,'',userid);
					setPageValue(memConfig,key,barcode,'');
				}
			});
		}else if('7008' == memConfig){
			$(".xzadd").parent().find("input[type=radio]").each(
			function(i){
				if($(this).attr("checked") == 'checked'){
					var key =$(this).val();
					var phone = '';
					if('2' == key){
						phone = $("#phone").val();
						var show = '<div class="r t" value="'+key+'">由['+phone+']带取&gt;</div>';
						$("#7008").find("div[value=1]").html(show);
					}else{
						var show = '<div class="r t" value="'+key+'">自取&gt;</div>';
						$("#7008").find("div[value=1]").html(show);
					}
					ebox.memberConfig(memConfig,key,phone,'',userid);
					setPageValue(memConfig,key,phone,'');
				}
			});
		}else if('7009' == memConfig){
			var show= '';
			var key1 ='';
			var eamil = '';
			$(".xzadd1").parent().find("input[type=checkbox]").each(function(i){
				if($(this).attr("checked") == 'checked'){
					var key =$(this).val();
					if('2' == key){
						if(key1 != ''){
							key1+=',';
						}
						key1+=key;
						eamil = $("#eamil").val();
						 show += '<div class="r t" value="'+key+'">由['+eamil+']邮件通知&gt;</div>';
					}else {
						if(key1 != ''){
							key1+=',';
						}
						key1+=key;
						 show += '<div class="r t" value="'+key+'">短信通知&gt;</div>';
					}
					
				}
			});
			$("#7009").find("div[value=1]").html(show);
			ebox.memberConfig(memConfig,key1,eamil,'',userid);
			setPageValue(memConfig,key1,eamil,'');
			
		}else if('7010' == memConfig){
			$(".xzadd").parent().find("input[type=radio]").each(
			function(i){
				if($(this).attr("checked") == 'checked'){
					var value =$(this).val();
					if('1' == value){
						var show = '<div class="r t" value="'+value+'">只发本人&gt;</div>';
						$("#7010").find("div[value=1]").html(show);
					}else if('2' == value){
						var show = '<div class="r t" value="'+value+'">只发代领人&gt;</div>';
						$("#7010").find("div[value=1]").html(show);
					}else if('3' == value){
						var show = '<div class="r t" value="'+value+'">本人+代领人&gt;</div>';
						$("#7010").find("div[value=1]").html(show);
					}
					ebox.memberConfig(memConfig,value,'','',userid);
					setPageValue(memConfig,value,'','');
				}
			});
		}else if('7011' == memConfig){
			$(".xzadd").parent().find("input[type=radio]").each(
			function(i){
				if($(this).attr("checked") == 'checked'){
					var value =$(this).val();
					var one = '',two='';
					if('4' == value){
						one = $("#valueOne").val();
						two = $("#valueTwo").val();
					}
					if('1' == value){
						var show = '<div class="r t" value="'+value+'">全时段&gt;</div>';
						$("#7011").find("div[value=1]").html(show);
					}else if('2' == value){
						var show = '<div class="r t" value="'+value+'">周一至周五&gt;</div>';
						$("#7011").find("div[value=1]").html(show);
					}else if('3' == value){
						var show = '<div class="r t" value="'+value+'">周六周日&gt;</div>';
						$("#7011").find("div[value=1]").html(show);
					}else if('4' == value){
						var show = '<div class="r t" value="'+value+'">自定义['+one+','+two+']&gt;</div>';
						$("#7011").find("div[value=1]").html(show);
					}
					ebox.memberConfig(memConfig,value,one,two,userid);
					setPageValue(memConfig,value,one,two);
				}
			});
		}
		

	}
	$(".post").remove();
    $(".allpost").remove();
}
var doRecharge = function(){
	new $.pos({
		title: "充值",
		width:900,center:true,top:20,left:30,//center：true 左右上下居中、false自定义top,left。
		formtitle:'<div class="con_tit dt">请输入充值金额</div>',
		id:'001',
		waitTime: 1000, //窗口淡入淡出的事件，如果不填写，则默认为0秒， 2000毫秒为2秒
		form:[
		 {"name":'元','val':'','input':'recharge'}]
	}).showRechargeWin_c();
	
}
function getform_c(suburl1, getid) {
	var money = $("#memberCenterChongzhi").val();
	if(isNaN(money) || money <=0){
		alert('请输入金额');
		return;
	}
	ebox.setMemberCenterMoney(money);
    rechang1();
}
//协议
function proto(){
	$('.info_t').attr("class","info_t1");
	$('.info8_c').attr("class","info8_c1");
	$('.btn').attr("class","btn1");
	$('.info9_c1').attr("class","info9_c");
	proto1();
}
function proto2(){
	$('.info_t').attr("class","info_t1");
	$('.info18_c').attr("class","info18_c1");
	$('.info9_c1').attr("class","info9_c");
	proto1();
}
function proto1(){
	$("#pContent").html(ebox.GetUserProtocol());
	$('#scrollbar1').tinyscrollbar();
      var tthieght=$(".overview").height();
	  $(".otop").click(function(){
		  tttop=$(".overview").css('top');
		  tttop=parseInt(tttop)+(-150); 
		$(".overview").animate({ top:tttop}, 500 );;
		}); 
		
		$(".obottom").click(function(){
		  tttop=$(".overview").css('top');
		  tttop=parseInt(tttop)+(150); 
		$(".overview").animate({ top:tttop}, 500 );

		}); 
}
//用户注册_短信验证
function regedi(){
	$('.info9_c').attr("class","info9_c1");
	$('.info8_c1').attr("class","info8_c");
	regedi1();
}
function regedi1(){
	ebox.SetBizCode('EBOX2047');
var ttxh='';
		$(".delin").click(function(){
		mr=$(this).parent().find('input').attr('mr');
			$(this).parent().find('input').val(mr);
		})
	$(".j_bot1").click(function(){
		var tel = $(this).parent().find('input').val();
		if(/^\d+$/.test(tel))
        {
			}else{
			ms('信息提示','手机号码不正确！');return false;
			}
		if($(this).attr("pd")=='y'){
			var r = json(ebox.registrationVerify(tel));
			if(!r.success)
			{
			//手机号码已注册
				ms('信息提示',r.msg);
				return ;
			}
			var msg1="ok";
			//$.ajax({
//type:'get',url:'index.php',cache:false,data:{tel:tel},dataType:'html',success:function(msg1){
	if(msg1=='ok'){
		ms('信息提示','验证码已经发送到您手机，请留意短信！');
		$(".j_bot1").removeClass('cur');
		$(".j_bot1").attr("pd",'n');
		$(".j_bot1").parent().find('input').attr("disabled",true);	
			$(".j_bot1").parent().find('img').hide();
			ttxh=setInterval("timeouts()",1000);
		}else{
			ms('信息提示','发送失败!');
			return false;
			}
//},error:function(){
//ms('信息提示','发送失败，请联系管理员');
//return false;
//}});
			}
		})
		
		$(".j_bot2").click(function(){
			var tel = $(".j_bot1").parent().find('input').val();
			var yzm=$(this).parent().find('input').val();
			var r = json(ebox.userRegist(tel,yzm));
			//$.ajax({
	//type:'get',url:'index.php',cache:false,data:{yzm:yzm},dataType:'html',success:function(msg){
	if(r.success){
			/**
			if(r.method==1)
				window.location.href="完善寄件信息.html"; 
			else 
				window.location.href="会员中心.html"; 
			*/
			window.location.href="用户名密码登录页-c2.html";
		}else{
			ms('信息提示','验证失败！');
			}
	//},error:function(){
	//ms('信息提示','验证失败！');
	//}});
		})
function timeouts(){
timetxt=$(".bottom3 b").text();

if(timetxt==0){
$(".j_bot1").addClass('cur');
$(".j_bot1 b").text(60);
$(".j_bot1").attr('pd','y');
$(".j_bot1").parent().find('input').attr("disabled",false);
$(".j_bot1").parent().find('img').show();
clearInterval(ttxh);
	return false;
	}
timetxt--
$(".bottom3 b").text(timetxt);
}
}
//充值选择
function rechang1(){
	$('.info20_c').attr("class","info20_c1");
	$('.info18_c3').attr("class","info18_c");	
	ebox.SetBizCode('EBOX2030');
	$("#recharge").val(ebox.getMemberCenterMoney());
}
//充值选择取消返回会员中心
function remember(){
	$('.info20_c1').attr("class","info20_c");
	$('.info18_c').attr("class","info18_c3");
	member1();
}
//当前余额选择支付方式
function changway2(){
	$('.info17_c').attr("class","info17_c1");
	$('.info19_c1').attr("class","info19_c");
	changway1();
}
function changway(){
	$('.info13_c').attr("class","info13_c1");
	$('.info19_c1').attr("class","info19_c");
	changway1();
}
function changway1(){
	var uiData=json(ebox.GetUiData()); 
	var accountMoney = 0;
	var userInfo = uiData.UserInfo;
	if(null != userInfo.userAccount){
		accountMoney = userInfo.userAccount.uaCurrActMoney;
	}
	$('#txtAccountMoney').val(accountMoney);
	$('#txtMoney').val(uiData.JiJianMoney);
	var needPay = uiData.JiJianMoney-accountMoney;
	$('#txtNeedPay').val(needPay);
	if(needPay>=0 ||accountMoney==0)
	{
		$('#divPic').show();
		$('#divNeedPay').show();
		$('#btnOk').hide();
	}else
	{
		$('#divPic').hide();
		$('#divNeedPay').hide();
		$('#btnOk').show();
	}

 $(".txt2 img").click(function(){
	 url=$(this).attr('url');
	 $("#formye").attr('action',url);
	 $("#formye").submit();
	 })	
}
//格口管理
function mouthmanage(){	
	$('.info3_c').attr("class","info3_c1");
	$('.info4_c1').attr("class","info4_c");
      $('#scrollbar1').tinyscrollbar();
	  $(".kk").live("click",function(){
		  var gkid=$(this).attr("id");
		  savegk(gkid); 
	  });
	ebox.SetBizCode('EBOX2037');
	$(this).doTimeout('EBOX2037', lazyTime, function() {
		loadSysMouthArk();
	});
}	
function  savegk11(gksaveid){
	var r = window.showModalDialog("格口修改.html",window,"dialogWidth=1000px;dialogHeight=550px;status=no;resizable=no;");
	if(r==1){
		window.location.reload();
	}
}
var mouthArkId = -1;
function  savegk(gksaveid){
	mouthArkId = gksaveid;
	var kk=$('.kk').each(function(){
		if($(this).attr("id") == gksaveid){
			var exp = '';
			if($(this).attr('state') == '使用'){
				exp = getExpressByMouthNo($(this).attr('no'));
			}
			var barcode = '',custPhone = '',kuaiDiPhone = '',kuaiDiName = '',kuaiDiComp = '';
			if('' != exp && exp != undefined){
				if(exp.eiMailType == '1'){
					//寄件
					custPhone = exp.eiStoreUserPhone;
				}else{
					//存件
					barcode = exp.eiBarcode;
					custPhone = exp.eiTakeUserPhone;
					kuaiDiPhone = exp.eiStoreUserPhone;
					kuaiDiName = exp.eiStoreUserName;
					kuaiDiComp = exp.eiLcName;
				}
			}
			a = new $.pos({
				title: "",
				width:900,center:true,top:20,left:30,//center：true 左右上下居中、false自定义top,left。
				suburl:"index.php",
				opensuburl:"index.php",//开锁url，传递id
				emptysuburl:"index.php",//清空url，传递id
				formtitle:'<div class="con_tit dt"><div class="l gkt1">编号：<span>'+$(this).attr('no')+'  '+$(this).attr('state')+'</span></div> <div class="r gkt2" ></div><div class="r gkt3" ></div></div>',
				id:$(this).attr('id'),
				form:[
					 {"name":'箱门类型','val':$(this).attr('type'),'input':'n1','option':mouthTypeList,'barcode':barcode,'custPhone':custPhone},
					 {"name":'设置状态','val':$(this).attr('state'),'input':'n3','option':'空闲|使用|占用','kuaiDiPhone':kuaiDiPhone,'kuaiDiName':kuaiDiName},
					 {"name":'箱门编号','val':$(this).attr('no'),'input':'n2','value':$(this).attr('no'),'kuaiDiComp':kuaiDiComp}
				]
			});
			a.show2();
			return false;
		}
	});
	
}

function openDoor(arkId){
	ebox.OpenBoxByArkId(arkId);
}
function closediv(id){
	$("." + id).remove();
    $(".allpost").remove();
}
function getExpressByMouthNo(no){
	if('' == expressList){
		return '';
	}
	for(var i = 0;i<expressList.length;i++){
		if(expressList[i].eiLatticeNo == no){
			return expressList[i];
		}
	}
}
function closediv122(id){
	var n1 = $("#n1").val();//类型
	var n2 = $("#n2").val();//编号
	var n3 = $("#n3").val();//状态
	if(mouthArkId > 0){
		if(isNaN(n2)){
			alert('格口编号无效');
			return;
		}
		ebox.modifyMouthArk(mouthArkId,n1,n2,n3);
	}
	$("." + id).remove();
    $(".allpost").remove();
	window.location.reload();
}
var mouthTypeList = '';
var mouthNoList = '';
var expressList = '';
function loadSysMouthArk(){
	var mouthArkJson =json(ebox.loadAllMouthList());
	var m = mouthArkJson.mouth;
	if(null != m && m.length > 0){
		for(var i = 0;i<m.length;i++){
			mouthTypeList +=m[i].moModel+'|';
		}
		if(mouthTypeList.length > 0){
			mouthTypeList = mouthTypeList.substring(0,mouthTypeList.length-1);
		}
	}
	if(null != mouthArkJson.expressList && mouthArkJson.expressList.length >0){
		expressList = mouthArkJson.expressList;
	}
	var v = mouthArkJson.mouthArk;
	if(null != v && v.length > 0){
		var mouthList = '';
		for(var i =0;i<v.length;i++){
			mouthNoList += v[i].moNo+'|';
			if('1' == v[i].buzStatus){//空闲
				mouthList +="<div class='kk' type='"+v[i].moTypeName+"' state='空闲' no='"+v[i].moNo+"' id='"+v[i].id+"'>";
				mouthList +="<div class='k1'>"+v[i].moNo+"</div>";
			}else if('2' == v[i].buzStatus){//使用
				mouthList +="<div class='kk' type='"+v[i].moTypeName+"' state='使用' no='"+v[i].moNo+"' id='"+v[i].id+"'>";
				mouthList +="<div class='k2'>"+v[i].moNo+"</div>";
			}else{//系统占用
				mouthList +="<div class='kk' type='"+v[i].moTypeName+"' state='占用' no='"+v[i].moNo+"' id='"+v[i].id+"'>";
				mouthList +="<div class='k3'>"+v[i].moNo+"</div>";
			}
			if('1' == v[i].moColor){
				mouthList +="<div class='s1' style='background:#708069'>"+v[i].moTypeName+"</div>";
			}else if('2' == v[i].moColor){
				mouthList +="<div class='s1' style='background:#00B0F0'>"+v[i].moTypeName+"</div>";
			}
			else if('3' == v[i].moColor){
				mouthList +="<div class='s1' style='background:#7E649E'>"+v[i].moTypeName+"</div>";
			}
			else if('4' == v[i].moColor){
				mouthList +="<div class='s1' style='background:#EA700D'>"+v[i].moTypeName+"</div>";
			}
			else if('5' == v[i].moColor){
				mouthList +="<div class='s1' style='background:#31859B'>"+v[i].moTypeName+"</div>";
			}
			else if('6' == v[i].moColor){
				mouthList +="<div class='s1' style='background:#BF9000'>"+v[i].moTypeName+"</div>";
			}
			mouthList +="</div>";
		}
		$(".overview").html(mouthList);
	}
}
//格口管理返回管理员登录界面
function readm1(){
	$('.info3_c1').attr("class","info3_c");
	$('.info4_c').attr("class","info4_c1");
	adm1();
}
//格口价格修改
function modifprice(){
	$(".express").hide();
	ebox.SetBizCode('EBOX2045');
	var v = json(ebox.loadMouthArkInfo());
	if(null != v){
		
	}
function submit(){
	var list = getPageInfo();
	if('-1' == list){
		return;
	}
	ebox.updateMouthPrice(list);
	window.returnValue=1;
	window.close();
}
function getPageInfo(){
	var list = '-1';
	$(".gksearch").find("tr").each(function(){
		var id = $(this).find("input[type=hidden]").val();
		var unitprice = $(this).find("input[type=text]").val();
		if(null == unitprice || ''==$.trim(unitprice)){
			ms('系統提示', '请输入格口费用');
			return '-1';
		}
		list +='{"moPrice":'+unitprice+',"moId":'+id+'},';
	});
	if('-1'==list){
		return "-1";
	}
	list = '['+list.substring(0,list.length-1)+']';
	return list;
}
}
//格口修改
function gridmodif(){
	$('.info4_c').attr("class","info4_c1");
	$('.info7_c2').attr("class","info7_c");
	$(".express").hide();
	ebox.SetBizCode('EBOX2043');
	var v = json(ebox.loadMouthArkInfo());
	if(null != v){
		var mouthArkInfo = v.mouthArk;
		var mouthType = v.mouthType;
		var mouthNum = v.mouthNum;
		var express = v.express;
		var mouthStatus = v.mouthStatus;
		if(null != mouthArk){
			$("#mouthArkId").val(mouthArk.id);
			$("#No").text(mouthArk.moNo);
			$("#status").text(mouthArk.buzstatusdesc);
			//格口类型
			if(null != mouthType && mouthType.length > 0){
				$("#mouthArkType").find("option").remove();
				var sel = $("#mouthArkType")[0];
				var _options = obj.options;
				for(var i =0;i<mouthType.length;i++){
					var op = new Option(mouthType[i].momodel ,mouthType[i].moid);
					if(mouthType[i].moid == mouthArk.motypeid){
						op.selected = true;
					}
					_options.add(op);
				}
			}
			//格口编号
			if(null != mouthNum && mouthNum.length > 0){
				$("#mouthArkNo").find("option").remove();
				var sel = $("#mouthArkNo")[0];
				var _options = obj.options;
				for(var i=0;i<mouthNum.length;i++){
					var op = new Option(mouthNum[i].moNo ,mouthNum[i].moNo);
					if(mouthNum[i].moNo == mouthArk.moNo){
						op.selected = true;
					}
					_options.add(op);
				}
			}
			//格口状态
			if(null !=mouthStatus && mouthStatus.length > 0){
				$("#mouthArkStatus").find("option").remove();
				var sel = $("#mouthArkStatus")[0];
				var _options = obj.options;
				for(var i =0;i<mouthStatus.length;i++){
					var op = new Option(mouthStatus[i].scname ,mouthStatus[i].syscode);
					if(mouthStatus[i].syscode == mouthArk.buzstatus){
						op.selected = true;
					}
					_options.add(op);
				}
			}
			//是否存放快件
			if(null != express){
				$(".express").show();
				if('1' == express.eimailtype){
					$("#storeUserName").text("取件人姓名："+express.eiStoreUsername);
					$("#storeUserPhone").text("取件人手机："+express.eiStoreUserphone);
				}else{
					$("#storeUserName").text("快递员姓名："+express.eiStoreUsername);
					$("#storeUserPhone").text("快递员手机："+express.eiStoreUserphone);
					$("#phone").text("快递员手机："+express.takeuserphone);
					$("#barcode").text("运单号："+express.eibarcode);
					$("#expressStatus").text("快件状态："+express.tfbuzstatusdesc);
				}
			}
		}
	}
function submit(){
	ebox.modifyMouthArk($("#mouthArkId").val(),$("#mouthArkId").val(),$("#mouthArkNo").val(),$("#mouthArkStatus").val());
	window.returnValue=1;
	window.close();
}
}
//寄件称重
function expweigh(){
	$('.info12_c').attr("class","info12_c1");
	$('.info13_c1').attr("class","info13_c");
	ebox.SetBizCode('EBOX2010');
	ebox.SetCmpID(getUrlParam('CmpID'));
	ebox.InitElcWeight();
	$(".upform").click(function(){
		$("#form").submit();
		})
}

function OnShowWeight(weight){
	$('#TextGetWeight').val(weight);
}
function OnReadWeight(weight,money)
{
	$('#TextGetWeight').val(weight);
	$('#txtMoney').val(money);
}
function jumpNext(){
	var money  = $('#txtMoney').val();
	alert(money);
	changway();
	if(money != null && parseFloat(money) > 0){
		changway();
	}else{	
		changway();
	}
}
//条码打印
function barprint(){
	$('.info17_c').attr("class","info17_c1");
	$('.info14_c1').attr("class","info14_c");
	barprint1();
}
function barprint2(){
	$('.info19_c').attr("class","info19_c1");
	$('.info14_c1').attr("class","info14_c");
	barprint1();
}
function barprint1(){
	function printBarCode(){
		$("#printBarCode").attr("onclick","");
		ebox.PrintBarCode();
	}
	$(window).load(function(){
		ebox.PrintBarCode();
	});
}
//系统信息
function sysmsg(){
	$('.info3_c').attr("class","info3_c1");
	$('.info_c1').attr("class","info_c");
  $(".modify").click(function(){
	var urlid=$(this).attr("id");//id表示
	if(urlid == '03'){
		var r = window.showModalDialog("格口价格修改.html",window,"dialogWidth=1000px;dialogHeight=550px;status=no;resizable=no;");
		if(r==1){
			window.location.reload();
		}
	}
  });
    $(this).doTimeout('EBOX2036', lazyTime, function() {
		loadSysInfoList();
	});
}
function loadSysInfoList(){
ebox.SetBizCode('EBOX2036');
  var v = json(ebox.loadSysInfo());
  if(null != v.op && v.op.length > 0){
	  $("#opName").text(v.op[0].opName);
	  $("#opNo").text(v.op[0].opNo);
	  $("#opContacts").text(v.op[0].opContacts);
	  $("#opConPhone").text(v.op[0].opConPhone);
	  $("#opAddress").text(v.op[0].opAddress);
  }
  if(null != v.sys && v.sys.length > 0){
	$("#sysNo").text(v.sys[0].pbCrtNo);
	$("#sysAbbr").text(v.sys[0].pbAbbr);
	$("#sysStoreNum").text(v.sys[0].storeNum);
	$("#sysMouthNum").text(v.sys[0].mouthNum);
  }
  if(null != v.version){
	$("#sysVersion").text(v.version.version);
  }
  if(null != v.mouth){
	var list = v.mouth;
	var mouthInfo = '';
	var rowCount = Math.floor(list.length%2==0? list.length/2:list.length/2+1);
	
	for(var i =0;i<list.length;i++){
		if(i%2 == 0){
			mouthInfo +='<tr>';
			mouthInfo +='<td width="152" ' +( i==0?' height="30" ':'' )+'align="right" valign="bottom">'+list[i].moModel+'</td>';
			mouthInfo +='<td width="33" valign="middle">&nbsp;</td>';
			mouthInfo +='<td width="51" align="left" valign="bottom">'+list[i].moPrice+'</td>';
			mouthInfo +='<td width="69" align="left" valign="bottom">[ '+list[i].buzStatusName+'］</td>';
		}else
		{
			mouthInfo+='<td  width="74"  align="right" valign="middle">'+list[i].moModel+'</td>';
			mouthInfo+='<td  width="81"  align="center" valign="middle">'+list[i].moPrice+'</td>';
			mouthInfo+='<td   width="167" align="left" valign="middle">[ '+list[i].buzStatusName+'］</td>';
		}

		if(i == 0){
			mouthInfo +='<td width="267" rowspan="'+ rowCount +'" align="center" valign="bottom"></td>';
		}
		if(i%2 == 1){
			mouthInfo +='</tr>';
		}
	}
	$("#mouthList").html(mouthInfo);
  }
}
//系统信息返回管理员登录界面
function readm(){
	$('.info3_c1').attr("class","info3_c");
	$('.info_c').attr("class","info_c1");
	adm1();
}
//显示发送支付短信
function sendmsg(){
	$('.info19_c').attr("class","info19_c1");
	$('.info17_c1').attr("class","info17_c");
	sendmsg1();
}
function sendmsg2(){
	$('.info15_c').attr("class","info15_c4");
	$('.info17_c1').attr("class","info17_c");
	sendmsg1();
}
function sendmsg1(){
	ebox.SetBizCode('EBOX2013');
	var uiData=json(ebox.GetUiData()); 
	var accountMoney = uiData.UserInfo.userAccount.uaCurrActMoney;
	var needPay = uiData.JiJianMoney-accountMoney;
	$('#txtNeedPay').val(needPay);
	$('#bankPhone').val(uiData.UserInfo.userInfo.ciUserPhone);

}
function validateCustAccount1(vid){
	var r = json(ebox.validateMoney());
	if(r.success){
		$("." + vid).remove();
		$(".allpost").remove();
		barprint();
	}else{
		alert('充值金额还未到账，请稍候再试');
	}
}
function sendSMS2(){
	if($.trim($("#bankPhone").val()) == ''){
		ms('系統提示','请输入办理银行卡手机号');
		return;
	}
	if(confirm('确认手机号['+$("#bankPhone").val()+']为办理银行卡手机？')){
		ebox.userSMSRecharge($('#txtNeedPay').val(),$("#bankPhone").val());
		sendSMS3();
		var r = 1;//window.showModalDialog("显示支付短信发送中.html",window,"dialogWidth=700px;dialogHeight=350px;status=no;resizable=no;");
		if(r == 1){
			//geturl('条码打印.html');
		}
	}
}

function sendSMS3(){
	formhtml=getHtmlCon1();
	a = new $.pos({
		title: '短信充值中',
		width:700,center:true,top:20,left:30,//center：true 左右上下居中、false自定义top,left。
		url:'',
		form:formhtml
		});
	a.subdiy4();
}
function getHtmlCon1(){
	var html = '<div class="cen">';
html+='<table width="689" border="0" cellspacing="0" cellpadding="0" style="background:none;">';
  html+='<tr>';
    html+='<td height="87">&nbsp;</td>';
  html+='</tr>';
  html+='<tr>';
   html+='<td height="64" style=" background:url(images/info/eb.png) no-repeat 250px  10px;"><div class=" f20 t_l" style="margin-left:350px;">支付短信已经发送至您的个人<br />手机，请通过手机完成支付</div></td>';
  html+='</tr>';
  html+='<tr>';
    html+='<td height="30">&nbsp;</td>';
  html+='</tr>';
  html+='<tr>';
    html+='<td height="58" class="t f18" align="center">正在发送......</td>';
  html+='</tr>';
  html+='<tr>';
   html+=' <td height="34">&nbsp;</td>';
  html+='</tr>';
  html+='<tr>';
    html+='<td class="f18 t_l t"><div style="padding:15px; "><span class="f_f f_b">温馨提示：</span><br />';
      html+='支付过程中，等充值成功后点击【确定】按钮进入下一步，若您充值未成功点击【确定】时，系统扔在该页面等待，或请取消短信充值点击<span class="tt f_b">［深圳通支付］</span></div></td>';
  html+='</tr>';
html+='</table>';
   html+=' </div>';
   return html;
}
//显示发送支付短信-c
function sendmsgc(){
	$('.info18_c').attr("class","info18_c3");
	$('.info17_c2').attr("class","info17_c");
	ebox.SetBizCode('EBOX2032');
	var uiData=json(ebox.GetUiData());
	$('#txtNeedPay1').val(ebox.getMemberCenterMoney());
	$('#bankPhone1').val(uiData.UserInfo.userInfo.ciUserPhone);
}
function sendmsgc1(){
	$('.info15_c').attr("class","info15_c2");
	$('.info17_c2').attr("class","info17_c");
	ebox.SetBizCode('EBOX2032');
	var uiData=json(ebox.GetUiData());
	$('#txtNeedPay1').val(ebox.getMemberCenterMoney());
	$('#bankPhone1').val(uiData.UserInfo.userInfo.ciUserPhone);
}
function validateCustAccount(vid){
	var r = json(ebox.validateMoney());
	if(r.success){
		$("." + vid).remove();
		$(".allpost").remove();
		remember1();
	}else{
		alert('充值金额还未到账，请稍候再试');
	}
}
function sendSMS1(){
	if($.trim($("#bankPhone1").val()) == ''){
		ms('系統提示','请输入办理银行卡手机号');
		return;
	}
	if(confirm('确认手机号['+$("#bankPhone1").val()+']为办理银行卡手机？')){
		ebox.userSMSRecharge($('#txtNeedPay1').val(),$("#bankPhone1").val());
		sendSMS();
		var r = 1;//window.showModalDialog("显示支付短信发送中.html",window,"dialogWidth=700px;dialogHeight=350px;status=no;resizable=no;");
		if(r == 1){
			//geturl('条码打印.html');
		}
	}
}

function sendSMS(){
	formhtml=getHtmlCon();
	a = new $.pos({
		title: '短信充值中',
		width:700,center:true,top:20,left:30,//center：true 左右上下居中、false自定义top,left。
		url:'',
		form:formhtml
		});
	a.subdiy3();
}
function getHtmlCon(){
	var html = '<div class="cen">';
html+='<table width="689" border="0" cellspacing="0" cellpadding="0" style="background:none;">';
  html+='<tr>';
    html+='<td height="87">&nbsp;</td>';
  html+='</tr>';
  html+='<tr>';
   html+='<td height="64" style=" background:url(images/info/eb.png) no-repeat 250px  10px;"><div class=" f20 t_l" style="margin-left:350px;">支付短信已经发送至您的个人<br />手机，请通过手机完成支付</div></td>';
  html+='</tr>';
  html+='<tr>';
    html+='<td height="30">&nbsp;</td>';
  html+='</tr>';
  html+='<tr>';
    html+='<td height="58" class="t f18" align="center">正在发送......</td>';
  html+='</tr>';
  html+='<tr>';
   html+=' <td height="34">&nbsp;</td>';
  html+='</tr>';
  html+='<tr>';
    html+='<td class="f18 t_l t"><div style="padding:15px; "><span class="f_f f_b">温馨提示：</span><br />';
      html+='支付过程中，等充值成功后点击【确定】按钮进入下一步，若您充值未成功点击【确定】时，系统扔在该页面等待，或请取消短信充值点击<span class="tt f_b">［深圳通支付］</span></div></td>';
  html+='</tr>';
html+='</table>';
   html+=' </div>';
   return html;
}
//显示支付短信-c取消返回会员中心
function remember1(){
	$('.info20_c1').attr("class","info20_c");
	$('.info17_c').attr("class","info17_c2");
	member1();
}
//显示支付短信发送中
function sendingmsg(){
	var t = null;
	t = setInterval("timeget()",1000);
	$("#confirm").attr("disabled","disabled");
	var gn = parseInt(Math.random()*100+1);
	$("#gridNum").html(gn);
function timeget(){
	timetxt=$(".time").text();
	if(timetxt==0){
		$("#confirm").removeAttr("disabled");
		clearInterval(t);
		return false;
	}
	timetxt--
	$(".time").text(timetxt);
}
function submit(){
	var r = json(ebox.validateMoney());
	if(r.success){
		window.returnValue=1;
		window.close();
	}else{
		ms('系統提示', '充值金额还未到账，请稍候再试');
	}
}
}
//显示支付金额
function payment(){
	$('.info17_c').attr("class","info17_c2");
	$('.info15_c4').attr("class","info15_c");
	setInterval("timeget3()",1000);
}
function payment1(){
	$('.info17_c').attr("class","info17_c1");
	$('.info15_c4').attr("class","info15_c");
	setInterval("timeget3()",1000);
}
function timeget3(){
timetxt=$(".time3").text();
if(timetxt==0){
	location.href = "index.html";
	return false;
	}
timetxt--
$(".time3").text(timetxt);
	}

//显示支付金额-c
function payment2(){
	setInterval("timeget()",1000);
function timeget(){
timetxt=$(".time").text();
if(timetxt==0){
	member2();
	return false;
	}
timetxt--
$(".time").text(timetxt);
	}
}
//选择格口
function selectMou(){
	$('.info14_c').attr("class","info14_c1");
	$('.info16_c1').attr("class","info16_c");
	selectMou1();
}
function selectMou1(){
	$(window).load(function() {
	//setTimeout("geturl('格口打开.html')",3000);
	 ebox.SetBizCode('EBOX2015');
	//var list= json(ebox.GetFreeMouthToCust());
	var list = json(ebox.GetFreeMouthList());
	$('#tbList td').html('&nbsp;');
	$('#tbList td').click(function(){
		if($(this).attr('moTypeId')){
			geturl('格口打开_个人.html?moTypeId='+ $(this).attr('moTypeId'));
		}
	});
	var map = new Map("mouthArk1");
	for(var i =0;i<list.length;i++){
		if(list[i].status == '1'){
			var value = map.get(list[i].momodel);
			if(value == ""){
				map.put(list[i].momodel,list[i].count+"");
			}else{
				map.put(list[i].momodel,(parseFloat(value)+parseFloat(list[i].count))+"");
			}
		}
	}
	var tmp = [];
	for(var i=0;i<list.length;i++)
	{
		var ex = true;
		for(var j=0;j<tmp.length;j++){
			if(list[i].momodel == tmp[j]){
				ex = false;
				break;
			}
		}
		if(ex){
			tmp.push(list[i].momodel);
		}
	}
	for(var i=0;i<tmp.length;i++)
	{
		var val = map.get(tmp[i]);
		if('' != val && '-1' != val){
			var td=  $('#tbList td:eq('+i+')');
			td.html("&nbsp;&nbsp;"+tmp[i]);
			td.attr('moTypeId',getTypeId(list,tmp[i]));
		}else{
			var td=  $('#tbList td:eq('+i+')');
			td.html("&nbsp;&nbsp;<span>"+tmp[i]+"</span>");
			td.attr('moTypeId','');
		}
	}
	map.clearMap();
	/*for(var i=0;i<list.length;i++)
	{
		var td=  $('#tbList td:eq('+i+')');
		td.html(list[i].momodel+"|"+list[i].count);
		td.attr('moTypeId',list[i].moTypeId);
	}*/
});
function getTypeId(list,model){
	for(var i=0;i<list.length;i++){
		if(list[i].momodel == model){
			return list[i].moTypeId
		}
	}
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
       if ( typeof (key) != "string") {  
           throw "key must be a string!";  
       }  
       if ( typeof (value) != "string") {  
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
            for (var attr in mapContainer[index]) {  
                //alert(mapContainer[index][attr]);  
                if (attr != "id") {  
                    return false;  
                }  
            }  
        }  
        return true;  
    } 
	Map.prototype.size = function(){
		return this.MAPID;
	}
    Map.prototype.showMap = function() {  
        var index = -1;  
        index = this.getMapIndex();  
        var str = "";  
        if (this.id != null) {  
            str = "Map:\t" + this.id + "\n";  
            for (var attr in mapContainer[index]) {  
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
}
//运营商修改
function optmodify(){
	$(".express").hide();
	ebox.SetBizCode('EBOX2043');
	var v = json(ebox.loadMouthArkInfo());
	if(null != v){
		var mouthArkInfo = v.mouthArk;
		var mouthType = v.mouthType;
		var mouthNum = v.mouthNum;
		var express = v.express;
		var mouthStatus = v.mouthStatus;
		if(null != mouthArk){
			$("#mouthArkId").val(mouthArk.id);
			$("#No").text(mouthArk.moNo);
			$("#status").text(mouthArk.buzstatusdesc);
			//格口类型
			if(null != mouthType && mouthType.length > 0){
				$("#mouthArkType").find("option").remove();
				var sel = $("#mouthArkType")[0];
				var _options = obj.options;
				for(var i =0;i<mouthType.length;i++){
					var op = new Option(mouthType[i].momodel ,mouthType[i].moid);
					if(mouthType[i].moid == mouthArk.motypeid){
						op.selected = true;
					}
					_options.add(op);
				}
			}
			//格口编号
			if(null != mouthNum && mouthNum.length > 0){
				$("#mouthArkNo").find("option").remove();
				var sel = $("#mouthArkNo")[0];
				var _options = obj.options;
				for(var i=0;i<mouthNum.length;i++){
					var op = new Option(mouthNum[i].moNo ,mouthNum[i].moNo);
					if(mouthNum[i].moNo == mouthArk.moNo){
						op.selected = true;
					}
					_options.add(op);
				}
			}
			//格口状态
			if(null !=mouthStatus && mouthStatus.length > 0){
				$("#mouthArkStatus").find("option").remove();
				var sel = $("#mouthArkStatus")[0];
				var _options = obj.options;
				for(var i =0;i<mouthStatus.length;i++){
					var op = new Option(mouthStatus[i].scname ,mouthStatus[i].syscode);
					if(mouthStatus[i].syscode == mouthArk.buzstatus){
						op.selected = true;
					}
					_options.add(op);
				}
			}
			//是否存放快件
			if(null != express){
				$(".express").show();
				if('1' == express.eimailtype){
					$("#storeUserName").text("取件人姓名："+express.eiStoreUsername);
					$("#storeUserPhone").text("取件人手机："+express.eiStoreUserphone);
				}else{
					$("#storeUserName").text("快递员姓名："+express.eiStoreUsername);
					$("#storeUserPhone").text("快递员手机："+express.eiStoreUserphone);
					$("#phone").text("快递员手机："+express.takeuserphone);
					$("#barcode").text("运单号："+express.eibarcode);
					$("#expressStatus").text("快件状态："+express.tfbuzstatusdesc);
				}
			}
		}
	}
function submit(){
	ebox.modifyMouthArk($("#mouthArkId").val(),$("#mouthArkId").val(),$("#mouthArkNo").val(),$("#mouthArkStatus").val());
	window.returnValue=1;
	window.close();
}	
}