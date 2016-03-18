
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
var cacheAddress = '';
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
	
	$('#btnOk').click(function(){
		if($.trim($("#txt_tel").val()) == ''){
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
		
		var pkgName = $.trim($("#txt_tel").val());
		var recName = $.trim($("#txtsl1").val());
		var recPhone = $.trim($("#jiJianTelTxt").val());
		var recAddr = $.trim($("#txtsl3").val());
		
		ebox.SaveJiJianInfo(proNo,proName,cityNo,cityName,conNo,conName,pkgName,recName,recPhone,recAddr);
		geturl('选择快递公司.html');
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
 
function setcolor() {
      choice=document.back.colar.selectedIndex
      new_colar=document.back.colar.options[choice].value
      document.bgColor= new_colar
      document.cookie= "backgroundcolor=" + new_colar
}
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
}