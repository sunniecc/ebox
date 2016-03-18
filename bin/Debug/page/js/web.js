window['ebox'] = window.external;
window['json'] = function (str) {
    return $.parseJSON(str);
}

 var scrollFunc=function(e){ 
  e=e || window.event; 
  if(e.wheelDelta && event.ctrlKey){//IE/Opera/Chrome 
   event.returnValue=false;
  }else if(e.detail){//Firefox 
   event.returnValue=false; 
  } 
 }  
  
 /*注册事件*/ 
 if(document.addEventListener){ 
 document.addEventListener('DOMMouseScroll',scrollFunc,false); 
 }//W3C 
 window.onmousewheel=document.onmousewheel=scrollFunc;//IE/Opera/Chrome/Safari 

var timeout = 0;
var lazyTime = 150;
var timer = '';
function timedCount()
{
	timeout = timeout +1;
	if(timeout > 60){
		geturl('index.html');
	}
	timer = setTimeout("timedCount()",1000)
};

$(function(){
    $('embed').hide();
})
window['getUrlParam'] = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }

function getAllProps(obj){    
        var names="";       
        for(var name in obj){       
           names+=name+": "+obj[name]+", ";  
        }  
        return names;
    }

//处理键盘事件 禁止后退键（Backspace）密码或单行、多行文本框除外
function banBackSpace(e){   
    var ev = e || window.event;//获取event对象   
    var obj = ev.target || ev.srcElement;//获取事件源   
    
    var t = obj.type || obj.getAttribute('type');//获取事件源类型  
    
    //获取作为判断条件的事件类型
    var vReadOnly = obj.getAttribute('readonly');
    var vEnabled = obj.getAttribute('enabled');
    //处理null值情况
    vReadOnly = (vReadOnly == null) ? false : vReadOnly;
    vEnabled = (vEnabled == null) ? true : vEnabled;
    
    //当敲Backspace键时，事件源类型为密码或单行、多行文本的，
    //并且readonly属性为true或enabled属性为false的，则退格键失效
    var flag1=(ev.keyCode == 8 && (t=="password" || t=="text" || t=="textarea") 
                && (vReadOnly==true || vEnabled!=true))?true:false;
   
    //当敲Backspace键时，事件源类型非密码或单行、多行文本的，则退格键失效
    var flag2=(ev.keyCode == 8 && t != "password" && t != "text" && t != "textarea")
                ?true:false;        
    
    //判断
    if(flag2){
        return false;
    }
    if(flag1){   
        return false;   
    }   
}
$(function () {
timedCount();
	$(this).click(function(){timeout = 0;});
　　  //禁止后退键 作用于Firefox、Opera
document.onkeypress=banBackSpace;
//禁止后退键  作用于IE、Chrome
document.onkeydown=banBackSpace;
document.onselectstart=function(event){
if($(window.event.srcElement).is("input")){
return true
};
return false
};
document.oncontextmenu=function(){return false};
document.ondragstart=function(){return false};
document.onbeforecopy=function(){return false};
//document.oncopy=document.selection.empty();
//document.onselect=document.selection.empty();
});

(function ($) {
    $.pos = function (arr) {
        var name = "你好";     //这个是私有变量，外部无法访问
        var html = "";
        var html2 = "";
        var injson = "";
        var html23 = "";
        this.show = function () {
            $.each(arr.form, function (index, bc) {
                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
                html2 += '<tr><td width="80" height="60" align="center" class="i2tts"><input name="name" type="radio" value="1" class="hide" /><input name="id[]" type="checkbox" value="1" class="dei" /><img src="images/info/checkbox1.png"   class="c" /></td><td width="96" align="left">' + bc.name + '</td><td width="204"><div class="input1"><input  name="' + bc.input + '" type="text" value="' + bc.val + '" id="eamil' + index + '" onBlur="test(\'eamil' + index + '\',\'jpsrf\');" onfocus="test(\'eamil' + index + '\',\'jpsrf\');" /></div></td></tr>';
            });

            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += html2
            html += '<tr><td height="60" colspan="3" align="center"><input name="" type="image" src="images/post/sub.png" /></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
            $(".i2tts .c").click(function () {
                if ($(this).parent().find('input').eq(0).attr("checked")) {
                    $(this).parent().find("img").attr("src", "images/info/checkbox1.png");
                    $(this).parent().find("input").attr("checked", false);
                } else {
                    $(this).parent().find("img").attr("src", "images/info/checkbox2.png");
                    $(this).parent().find("input").attr("checked", "checked");
                }
            });
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });

            }


        };

        this.showRechargeWin = function () {
            var i = 0;
            $.each(arr.form,
            function (index, bc) {

                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
                i++;
                //alert(i);
                html23 += '<td height="60" width="205" style="padding-left:240px;" ><div class="input1 l"><input  name="' + bc.input + '" type="text" value="' + bc.val + '" /></div></td><td align="left">' + bc.name + '&nbsp;</td>';
                if (i == 2) {
                    i = 0;
                    html2 += '<tr>' + html23 + '</tr>';
                    html23 = "";
                } else {
                    html2 += '<tr>' + html23 + '</tr>';
                }

            });

            html += '<div class="post delete" style="display:none;top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%"  border="0" cellpadding="0" cellspacing="0" >';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="700" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += html2;
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += '<tr><td height="60" colspan="3" align="center" style="padding-left:180px;"><div class="bottom fyh l" onclick="closeWin(\'post\');">取消</div><div class="bottom fyh l" onclick="getform(\'' + arr.opensuburl + '\',\'' + arr.id + '\');">确定</div></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);

            (function () {
                $("body").find('.post.delete').fadeIn(arr.waitTime || 0);
            })();

            $("body").append('<div class="allpost"></div>');
            //alert(html);
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({
                    'left': sleft,
                    'top': sstop
                });
            }
        };

        this.showRechargeWin_c = function () {
            var i = 0;
            $.each(arr.form,
            function (index, bc) {
                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
                i++;
                html23 += '<td height="60" width="205" style="padding-left:240px;" ><div class="input1 l"><input onfocus="zzsz(this,true);" name="' + bc.input + '" type="text" id="memberCenterChongzhi" value="' + bc.val + '" /><div id="xnszjp-contain"></div></div></td><td align="left">' + bc.name + '&nbsp;</td>';
                if (i == 2) {
                    i = 0;
                    html2 += '<tr>' + html23 + '</tr>';
                    html23 = "";
                } else {
                    html2 += '<tr>' + html23 + '</tr>';
                }
            });
            html += '<div class="post delete" style="display:none;top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%"  border="0" cellpadding="0" cellspacing="0" >';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="700" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += html2;
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += '<tr><td height="60" colspan="3" align="center" style="padding-left:180px;"><div class="bottom fyh l" onclick="closeWin(\'post\');">取消</div><div class="bottom fyh l" onclick="getform_c(\'' + arr.suburl1 + '\',\'' + arr.id + '\');">确定</div></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);

            (function () {
                $("body").find('.post.delete').fadeIn(arr.waitTime || 0);
            })();

            $("body").append('<div class="allpost"></div>');
            //alert(html);
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({
                    'left': sleft,
                    'top': sstop
                });
            }
        };

        this.showDeleteGkWin = function () {
            $.each(arr.form,
            function (index, bc) {
                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
                option = bc.option;
                option = option.split('|');
                html2 += '<tr><td width="84" height="60" align="left">&nbsp;</td><td width="100"><ul class="select"><li class="t1"><input name="' + bc.input + '" type="hidden" value="' + bc.val + '" /><a href="#">' + bc.val + '</a><div class="clear"></div><ul>';
                $.each(option,
                function (index1, bc1) {
                    html2 += '<li class="t2">' + bc1 + '';
                });
                html2 += '</li></ul></li></ul></td><td width="80" height="60" align="left">&nbsp;</td></tr>';
            });

            html += '<div class="post delete" style="display:none;top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%"  border="0" cellpadding="0" cellspacing="0" >';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="700" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += html2;
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += '<tr><td height="60" colspan="3" align="center" style="padding-left:180px;"><div class="bottom fyh l" onclick="closeWin(\'post\',' + arr.waitTime + ');">取消</div><div class="bottom fyh l" onclick="getform(\'' + arr.opensuburl + '\',\'' + arr.id + '\');">确定</div></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);

            (function () {
                $("body").find('.post.delete').fadeIn(arr.waitTime || 0);
            })();

            $("body").append('<div class="allpost"></div>');
            //alert(html);
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({
                    'left': sleft,
                    'top': sstop
                });
                //绑定事件
                $(".select .t1 a").click(function () {
                    $(".select .t1  ul").hide();
                    if ($(this).parent().find('ul').is(":hidden")) {
                        $(this).parent().find('ul').show();
                        // alert(1);
                    } else {
                        $(this).parent().find('ul').hide();
                    }

                    $(".select").css({
                        'z-index': 9998
                    });
                    $(this).parent().parent().css({
                        'z-index': 9999
                    });

                    return false;
                });

                $(".select .t2").click(function () {
                    txt = $(this).text();
                    $(this).parent().parent().find('a').text(txt);
                    $(this).parent().parent().find('input').val(txt);
                    $(this).parent().find('ul').show();

                });
                $(document).mouseup(function (event) {
                    if ($(event.target).parents(".select").length == 0) {
                        $(".select .t1 ul").hide();
                    }
                })

                //
            }
        };
		 this.messagez = function () {

            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="content" style="height:360px">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10"  style="height:360px"></td>';
            html += '<td class="concshow">';
            html += arr.formtitle;
            html += '</td>';
            html += '<td width="10"></td>';
            html += '</tr>';
			html +='<tr>';
			
            html += '</table>';
            html += '</div>';
            html += '<div style="margin-top:-50px"><table width="350" border="0" align="center" style="magin-top:10px"    cellpadding="0" cellspacing="0">';
            html += '<tr><td height="60" colspan="3" align="center" ><input name="" type="image" onclick="closediv(\'post\');" src="'+arr.title+'" /></td></tr>';
            html += '</table><div ></div><div  style="width:' + (arr.width - 26) + 'px"></div><div ></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });
            }
        };
		
		
  this.messageo = function () {

            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="60" colspan="3" align="center"><input name="" type="image" onclick="closediv(\'post\');" src="images/imgs/EUI_2_01/E_UI_2_10.png" /></td></tr>';
            html += '</table></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });

            }


        };
        this.message = function () {
            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="60" colspan="3" align="center"><input name="" type="image" onclick="closediv(\'post\');" src="images/imgs/UI_2_01/_UI_2_10.png" /></td></tr>';
            html += '</table></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });

            }


        };


        this.subdiy = function () {
            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="closediv(\'cancel\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content" >';
            html += '<form action="' + arr.url + '" method="post" id="postform"><table id="formTable" width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td align="center">' + arr.form + '</td></tr>';
            html += '<tr><td height="60"  align="center"><div style="width:450px;" class="ma"><div class="bottom l"  onclick="closediv(\'cancel\');" >取消</div><div class="r"><input onclick="closediv(\'submit\');"  name="" type="image" src="images/post/sub.png" /></div></div></td></tr>';
            html += '</table></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table></form>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
            $(".xzadd").click(function () {
                $(".xzadd").attr('src', 'images/info/row.png');
                $(this).attr('src', 'images/info/row1.png');
				var id = $(this).attr("id");
                $(this).parent().find('input').each(function(){
					if(id == $(this).val()){
						$(this).attr('checked', 'checked');
					}
				});
            });
			$(".xzadd12").click(function () {
				$(this).attr('src', '/images/info/checkbox2.png');
                $(this).parent().find('input[type=checkbox]').each(function(){
					if($(this).attr('checked') == 'checked'){
						$(this).removeAttr('checked');
					}else{
						$(this).attr('checked', 'checked');
					};
				});
            })
            $(".i2tts .c").click(function () {
                if ($(this).parent().find('input[type=checkbox]').attr("checked")) {
                    $(this).parent().find("img").attr("src", "images/info/checkbox1.png");
                    $(this).parent().find('input[type=checkbox]').removeAttr("checked");
                } else {
                    $(this).parent().find("img").attr("src", "images/info/checkbox2.png");
                    $(this).parent().find('input[type=checkbox]').attr("checked", "checked");
                }
            });
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });
            }
        };
		var t ;
 this.subdiy3 = function () {
            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<form action="' + arr.url + '" method="post" id="postform"><table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td align="center">' + arr.form + '</td></tr>';
            html += '<tr><td height="60"  align="center"><div style="width:450px;" class="ma"><div class="bottom l " onclick="closediv(\'post\');"  >取消</div> <div id="sdiv" class="bottomd r "  onclick="validateCustAccount(\'post\')"  style="color:#E2E2E2;">确定<span id="steam">30</span></div></div></td></tr>';
            html += '</table></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table></form>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
			
			//setInterval("timeget()",1000);
			t = setInterval(function() {
					timeget();
				}, 1000);
			
            $(".xzadd").click(function () {
                $(".xzadd").attr('src', 'images/info/row.png');
                $(this).attr('src', 'images/info/row1.png');
				var id = $(this).attr("id");
                $(this).parent().find('input').each(function(){
					if(id == $(this).val()){
						$(this).attr('checked', 'checked');
					}
				});
            })
            $(".i2tts .c").click(function () {
                if ($(this).parent().find('input').eq(0).attr("checked")) {
                    $(this).parent().find("img").attr("src", "images/info/checkbox1.png");
                    $(this).parent().find("input").attr("checked", false);
                } else {
                    $(this).parent().find("img").attr("src", "images/info/checkbox2.png");
                    $(this).parent().find("input").attr("checked", "checked");
                }
            });
            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });
            }
        };
		
		function timeget(){
				var timetxt=$("#steam").text();
				if(timetxt==0){
					clearInterval(t);
					$("#sdiv").removeClass("bottomd");
					$("#sdiv").addClass("bottom");
					$("#steam").text("");
					return false;
				}
				timetxt--
				$("#steam").text(timetxt);
			}
		
        this.subdiy2 = function () {
             html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<form action="' + arr.url + '" method="post" id="postform"><table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += '<table width="380" height="320" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td align="center">' + arr.form + '</td></tr>';
            html += '</table></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table></form>';
            html += '</div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');

            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });

            }
        };

        this.message1 = function () {
            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="260" colspan="3" align="center">';
            $.each(arr.form, function (aa, bb) {
                html += '<div class="bottom jjbot" onclick="geturl(\'' + arr.url + "?id=" + bb.id + "&name=" + bb.name + '\')">' + bb.name + '</div>';
            });
            html += '</td></tr>';
            html += '</table></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');

            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });
            }
        };

        this.show1 = function () {
            $.each(arr.form, function (index, bc) {
                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
                html2 += '<tr><td width="80" height="42" align="center" class="i2tts"><input name="name" type="radio" value="1" class="hide" /><input name="id[]" type="checkbox" value="1" class="dei" /><img src="images/info/checkbox1.png"   class="c" /></td><td width="120" align="left">' + bc.name + '</td><td width="204"><div class="input1"><input name="' + bc.input + '" type="text" value="' + bc.val + '" id="eamil' + index + '" onBlur="test(\'eamil' + index + '\',\'jpsrf\');" onfocus="test(\'eamil' + index + '\',\'jpsrf\');" /></div></td></tr>';
            });

            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="380" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += html2
            html += '<tr><td height="60" colspan="3" align="center"><input name="" type="image" src="images/post/sub.png" /></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');

            $(".i2tts .c").click(function () {
                if ($(this).parent().find('input').eq(0).attr("checked")) {
                    $(this).parent().find("img").attr("src", "images/info/checkbox1.png");
                    $(this).parent().find("input").attr("checked", false);
                } else {
                    $(this).parent().find("img").attr("src", "images/info/checkbox2.png");
                    $(this).parent().find("input").attr("checked", "checked");
                }
            });

            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });

            }


        };


        this.show2 = function () {
            $.each(arr.form, function (index, bc) {
                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
				var value= bc.val;
				if(undefined == value){
					value ="请选择";
				}
				if(bc.name == '箱门编号'){
					var comp = '';
					if(bc.kuaiDiComp != ''){
						comp = '快件公司名：'+bc.kuaiDiComp;
					}
					html2 += '<tr><td width="100" height="60" align="left">' + bc.name + ':</td><td width="100"><div class="input2"><input readonly="readonly" id="' + bc.input + '" type="text" value="' + value + '"/>';
					 html2 += '</div></td><td>'+comp+'</td></tr>';
				}
				else if(bc.name == '箱门类型'){
					var barcode ='';
					var custPhone ='';
					if(bc.barcode != ''){
						barcode = '运单号：'+bc.barcode;
					}
					if(bc.custPhone != ''){
						custPhone = '收件人电话：'+bc.custPhone;
					}
					option = bc.option;
					option = option.split('|');
					html2 += '<tr><td width="100" height="80" align="left">' + bc.name + ':</td><td width="200"><ul class="select"><li class="t1"><input id="' + bc.input + '" type="hidden" value="' + value + '" /><a href="#">' + value + '</a><div class="clear"></div><ul>';
					$.each(option, function (index1, bc1) {
						html2 += '<li class="t2" >' + bc1 + '';
					});
					html2 += '</li></ul></li></ul></td><td>'+barcode+'&nbsp;'+custPhone+'</td></tr>';
				}
				else{
					var kuaiDiName ='';
					var kuaiDiPhone ='';
					if(bc.kuaiDiName != ''){
						kuaiDiName = '快递员姓名：'+bc.kuaiDiName;
					}
					if(bc.kuaiDiPhone != ''){
						kuaiDiPhone = '快递员电话：'+bc.kuaiDiPhone;
					}
					option = bc.option;
					option = option.split('|');
					html2 += '<tr><td width="100" height="80" align="left">' + bc.name + ':</td><td width="200"><ul class="select"><li class="t1"><input id="' + bc.input + '" type="hidden" value="' + value + '" /><a href="#">' + value + '</a><div class="clear"></div><ul>';
					$.each(option, function (index1, bc1) {
						html2 += '<li class="t2" >' + bc1 + '';
					});
					html2 += '</li></ul></li></ul></td><td>'+kuaiDiName+'&nbsp;'+kuaiDiPhone+'</td></tr>';
				}
            });
            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%"  border="0" cellpadding="0" cellspacing="0" >';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="700" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += html2
            html += '<tr><td height="30" colspan="3" align="center">&nbsp;</td></tr>';
            html += '<tr><td height="60" colspan="3" align="center"><div class="bottom fyh l" onclick="openDoor(\'' + arr.id + '\');">开  锁</div><div class="l ml8" onclick="closediv122(\'post\')"><input name="" type="image" src="images/post/sub.png" /></div><div class="bottom fyh l" onclick="closediv(\'post\');">返 回</div></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');
            //alert(html);

            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });
                //绑定事件
                $(".select .t1 a").click(function () {
                    $(".select .t1  ul").hide();
                    if ($(this).parent().find('ul').is(":hidden")) {
                        $(this).parent().find('ul').show();
                        // alert(1);
                    } else {
                        $(this).parent().find('ul').hide();
                    }

                    $(".select").css({ 'z-index': 9998 });
                    $(this).parent().parent().css({ 'z-index': 9999 });

                    return false;
                });

                $(".select .t2").click(function () {
                    txt = $(this).text();
                    $(this).parent().parent().find('a').text(txt);
                    $(this).parent().parent().find('input').val(txt);
                    $(this).parent().find('ul').show();

                });
                $(document).mouseup(function (event) { if ($(event.target).parents(".select").length == 0) { $(".select .t1 ul").hide(); } })

                //

            }


        };

        this.show4 = function () {
            var i = 0;
            $.each(arr.form, function (index, bc) {

                if (index == 0) {
                    injson += bc.input;
                } else {
                    injson += ',' + bc.input;
                }
                i++;
                //alert(i);

                html23 += '<td height="60" width="200" align="right" >' + bc.name + '&nbsp;</td><td><div class="input1 l"><input name="' + bc.input + '" type="text" value="' + bc.val + '" /></div></td>';
                if (i == 2) {
                    i = 0;
                    html2 += '<tr>' + html23 + '</tr>';
                    html23 = "";
                    //alert(html2);
                }


            });

            html += '<div class="post" style="top:' + arr.top + 'px; left:' + arr.left + 'px; width:' + arr.width + 'px;">';
            html += '<div class="tit"><div class="close" onclick="javascript:closediv(\'post\');"></div><div class="titl"></div><div class="titc" style="width:' + (arr.width - 26) + 'px">' + arr.title + '</div><div class="titr"></div></div>';
            html += '<div class="content">';
            html += '<table width="100%" height="100" border="0" cellpadding="0" cellspacing="0">';
            html += '<tr>';
            html += '<td width="10" class="conl"></td>';
            html += '<td class="conc">';
            html += arr.formtitle;
            html += '<form id="formUpdate" json="' + injson + '" action="' + arr.suburl + '" onsubmit="return submitform();" target="_self"><input name="id" type="hidden" value="' + arr.id + '" />';
            html += '<table width="700" border="0" align="center"  class="fyh f20" cellpadding="0" cellspacing="0">';
            html += html2
            html += '<tr><td height="60" colspan="4"  align="center"><input name="" type="image" src="images/post/sub.png" /></td></tr>';
            html += '</table></form></td>';
            html += '<td width="10" class="conr"></td>';
            html += '</tr>';
            html += '</table>';
            html += '</div>';
            html += '<div class="foot"><div class="footl"></div><div class="footc" style="width:' + (arr.width - 26) + 'px"></div><div class="footr"></div></div></div>';
            $("body").append(html);
            $("body").append('<div class="allpost"></div>');

            if (arr.center) {
                sleft = (($(window).width() - arr.width) / 2);
                sstop = (($(window).height() - $(".post").height()) / 2);
                $(".post").css({ 'left': sleft, 'top': sstop });

            }


        };


    };

})(jQuery);


var closeWin = function (clazzName, waitTime) {
    $("." + clazzName).fadeOut(waitTime || 0, function () {
        $(this).remove();
    });
    $(".allpost").remove();
}

function closediv(vid) {
    $("." + vid).remove();
    $(".allpost").remove();
}
function closediv1(vid) {
    $("." + vid).remove();
	if(typeof(onzzszClosed) !='undefined' && window['zzszSrc']){
		onzzszClosed(window['zzszSrc']);
	}
}
function vode() {
    return false;
}


function submitform() {
    mds = $("#formUpdate").attr("json");
    suburl = $("#formUpdate").attr("action");
    var strs = new Array();
    if (mds != null) {
        strs = mds.split(",");
        $.each(strs, function (index, tx) {
            ddd = tx;
        });
    }
    $.ajax({
        type: 'post',
        url: suburl,
        cache: false,
        data: $("#formUpdate").serialize(),
        dataType: 'html',
        success: function (msg1) {
            //alert(msg1);
            location.reload();
        }, error: function () {//alert("error");
        }


    })

    //alert($("#formUpdate").html());
    return false;

}


function getform(suburl1, getid) {
    alert(suburl1 + '----' + getid);
    $.ajax({
        type: 'get',
        url: suburl1,
        cache: false,
        data: {
            id: getid
        },
        dataType: 'html',
        success: function (msg1) {
            //alert(msg1);
            location.reload();

        },
        error: function () {
            //alert("error");
        }
    });
}

function geturlmr(suburl1s, getids) {
    $.ajax({
        type: 'get', url: suburl1s, cache: false, data: { id: getids }, dataType: 'html', success: function (msg1) {
        }, error: function () {
            //alert("error");
        } 
    });
}

function geturl(url) {
    window.location.href = url;

}

function showErr(msg)
{
	ms('系統提示',msg);
}

function ms(mtit, con) {
    a = new $.pos({
        title: mtit,
        width: 500, center: true, top: 20, left: 30, //center：true 左右上下居中、false自定义top,left。
        formtitle: '<div class="con_con"><br>' + con + '</div>'
    });
	
    a.message();
	
}
function ms1(mtit, con) {
    a = new $.pos({
        title: mtit,
        width: 500, center: true, top: 20, left: 30, //center：true 左右上下居中、false自定义top,left。
        formtitle: '<div class="con_con"><br>' + con + '</div>'
    });
	
		a.messageo()
}

function ms2(img, con) {
    a = new $.pos({
        title: img,
        width: 753, center: true, top: 20, left: 30, //center：true 左右上下居中、false自定义top,left。
        formtitle: '<div style="magin-left:100px"><img src="'+ con + '"> </div>'
    });
	
		a.messagez()
}
function test(inid, inshowid) {
    VirtualKeyboard.toggle(inid, inshowid);
	$("#kb_langselector,#kb_mappingselector,#copyrights").css("display", "none");
	if($("#kb_langselector").css("display") == 'none'){
	
		if(inid =='txtsl3'){
			var objoffset = $("#"+inid).offset();
			$("#jpsrf").css("top", objoffset.top - $("#"+inid).height()-260);
		}else{
			var objoffset = $("#"+inid).offset();
			$("#jpsrf").css("top", objoffset.top + $("#"+inid).height() + 11);
		}
	}
}

function test1(inid, inshowid) {
    VirtualKeyboard.toggle(inid, inshowid);
    $("#kb_langselector,#kb_mappingselector,#copyrights").css("display", "none");
}

var smtep = 0;
function zzsz(sthis, vipCenter) {
    var htmlsz = '<div class="xnszjp" id="xnszjp"><ul><li class="s" value="1">1</li><li class="s" value="2">2</li><li class="s" value="3">3</li><li class="s" value="4">4</li><li class="s" value="5">5</li><li class="s" value="6">6</li><li class="s" value="7">7</li><li class="s" value="8">8</li><li class="s" value="9">9</li><li class="s" value="*">*</li><li class="s" value="0">0</li><li class="s" value="#">#</li><li class="nextTab" style="font-size:30px">下一项</li><li class="wc" onclick="closediv1(\'xnszjp\')" style="font-size:30px">确定</li><li class="j" style="font-size:30px">删除</li></ul></div>';
    
	if(vipCenter){
		$("#xnszjp-contain").append(htmlsz);
	} else {
		$(".info_all").append(htmlsz);
	}
	
    //$(sthis).parent().append(htmlsz);
    var objoffset = $(sthis).offset();
    var objoffset1 = $(sthis).parent().offset();

	if(!vipCenter){
		$(".xnszjp").css("left", objoffset1.left);
		$(".xnszjp").css("top", objoffset.top + $(sthis).height() + 11);
	}
    $(".xnszjp .s").click(function () {
		if($.trim($(sthis).val()) != '' && $(sthis).val().length > 25){
			return;
		}
        $(sthis).val($(sthis).val() + $(this).text());
    });
	$(".xnszjp li").mousedown(
	  function () {
		$(this).addClass("ss");
	  }
	);
	$(".xnszjp li").mouseup(function(){
		$(this).removeClass("ss");
	});
	window['zzszSrc'] = sthis;
	 $(".xnszjp .nextTab").click(function () {
		var id =  $(sthis).attr("id");
		var inputlength = $("input[type=text]").length;
		closediv1('xnszjp');
       $("input").each(function(i){
		   if(inputlength == 3){
				if($(this).attr("id") == id){
					if(smtep != 2){
						++smtep;
					}else{
						smtep = 1;
					}
				}
				if($(this).attr("id") != id && i == smtep ){
					$(this).focus();
					if(smtep == 2){
						smtep = 0;
					}
					return false ;
				 }
		   }else{
				 if($(this).attr("id") != id){
					$(this).focus();
					return false ;
				 }
		   }
	   })
    });
    $(".xnszjp .j").click(function () {
        var s = $(sthis).val();
        s = s.substring(0, s.length - 1);
        $(sthis).val(s);
    });
	
}

document.documentElement.onclick = function (e) {
    e = window.event ? window.event : e;
    var e_tar = e.srcElement ? e.srcElement : e.target;
    if ($(e_tar).is("li")) {
        var e_div_id = $(e_tar).parent().parent().attr("id");
        if (e_div_id == "xnszjp") {
            return;
        }
        else {
            closediv1('xnszjp');
        }
    } else if ($(e_tar).is("ul")) {
        var e_div_id = $(e_tar).parent().attr("id");

        if (e_div_id == "xnszjp") {
            return;
        }
        else {
            closediv1('xnszjp');
        }
    } else if ($(e_tar).is("div")) {
        var e_div_id = $(e_tar).attr("id");
        if (e_div_id == "xnszjp") {
            return;
        }
        else {
            closediv1('xnszjp');
        }
    } else {
        if (!$(e_tar).is("input") ) {
            closediv1('xnszjp');
			closediv1('xnszjp1');
        }else if(!($(e_tar).attr("id") == 'jiJianTelTxt')){
			closediv1('xnszjp1');
		}
    }

}