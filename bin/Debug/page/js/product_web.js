function videos(){
	return;
	}

$(function(){
caos=$(".rightnav li:eq(0)").attr("cid");
if(thiscidphp){
	caos=thiscidphp;
}else if(!caos){
	caos=id;
}
//alert(caos);
allshow2(caos);
//alert(caos);
pshowsl=$(".nyallwidth ul").size();
pshowwd=$(".nyallwidth ul").eq(0).width();
$(".confoot").eq(1).show(100);
$(".connav .s1").click(function(){
$(".connav .s1").removeClass("s2");
$(this).addClass("s2");
sid=$(this).attr("attr");
$(".confoot").hide(100);
$(".confoot").eq(sid).show(100);
})

$(".nyallwidth").width((pshowsl*pshowwd));
$(".nypright").click(function(){
	leftshow();		
 });
$(".nypleft").click(function(){	 
	 rightshow();				   
 });


$(".rightnav li").click(function(){
	$(".rightnav li").eq(0).removeClass("mm1");
	$(".rightnav li").eq(1).removeClass("mm2");
	$(".rightnav li").eq(2).removeClass("mm3");
	thisindex=$(".rightnav li").index($(this));
	$(this).addClass("mm"+(thisindex+1));

	allshow($(this).attr("cid"));
								 
})


});

   
function leftshow(){
	//alert(parseInt($(".nyallwidth").css("margin-left")));
	if((parseInt($(".nyallwidth").css("margin-left"))+(-540))>(-parseInt($(".nyallwidth").width()))){
$(".nyallwidth").animate({marginLeft: '-=' + 540}, 400);
		}else{
			rightshow();
			};
}
	
function rightshow(){
	if(parseInt($(".nyallwidth").css("margin-left"))>=0){
		leftshow();
		}else{
	$(".nyallwidth").animate({marginLeft: '+=' + 540}, 400);
	}
}


function allshow(thcon){
	$(".nyallwidth").css({"margin-left":0});
  $.ajax({
type:'get',url:"http://web.fuguang.raysog.com/all_pro_"+thcon,cache:false,data:{class1:0},dataType:'JSON',success:function(msg){
	 var html1='';
	 var html2='';
	 var i=0;
$(".nyallwidth").html('');
 $.each(msg,function(index,b){
					 i++;
					  if(b['pic']){
					 	pic2=b['pic'][0]['picx'];
					 }else{
					 	pic2=b['pic']='http://web.fuguang.raysog.com/public/Index/images/noimg.jpg';
					 }
html1+="<ul cid="+b.id+"><li class=img ><a href='javascript:prodes("+b.id+");'><img src='"+b['pic'][0]['pic']+"' height='128' /></a></li><li class='txt'><a href=''>"+b.title+"</a></li></ul>";

   });

$(".nyallwidth").width(180*i);
$(".nyallwidth").html(html1);
},error:function(){alert("error");}


})
  
  
    $.ajax({
type:'get',url:"http://web.fuguang.raysog.com/all_classtxt_"+thcon,cache:false,data:{class1:0},dataType:'JSON',success:function(msg1){
$(".class_des").html(msg1['des']);
$(".class_tit").html(msg1['name']);


},error:function(){//alert("error");
}


})


}

function allshow2(thcon){

	$(".nyallwidth").css({"margin-left":0});

  $.ajax({
type:'get',url:"http://web.fuguang.raysog.com/all_pro_"+thcon,cache:false,data:{class1:0},dataType:'JSON',success:function(msg){
	 var html11='';
	 var html21='';
	 var ir=0;

$(".nyallwidth").html('');
 $.each(msg,function(index,b){
					 ir++;
					 if(b['pic']){
					 	pic2=b['pic'][0]['picx'];
					 }else{
					 	pic2=b['pic']='http://web.fuguang.raysog.com/public/Index/images/noimg.jpg';
					 }
					 
html11+="<ul cid="+b.id+"><li class=img ><a href='javascript:prodes("+b.id+");'><img src='"+pic2+"' height='128' /></a></li><li class='tx'><a href=''>"+b.title+"</a></li></ul>";
   });

 if(dlid){
	prodes(dlid);
	 }else{ 
prodes(msg[0]['id']);
	 }
$(".nyallwidth").width(180*ir);
$(".nyallwidth").html(html11);
},error:function(){//alert("error1");
}


})
  
  
    $.ajax({
type:'get',url:"http://web.fuguang.raysog.com/all_classtxt_"+thcon,cache:false,data:{class1:0},dataType:'JSON',success:function(msg1){
$(".class_des").html(msg1['des']);
$(".class_tit").html(msg1['name']);


},error:function(){//alert("error");
}


})


}
function htlmdlsa(str) {
 str = str.replace(/\\'/g,'\'');
 
                str = str.replace(/\\"/g,'"');
 
                str = str.replace(/\\\\/g,'\\');
 
                str = str.replace(/\\0/g,'\0');
 
                return str;
 
}

function prodes(thcon){

 $.ajax({
type:'get',url:"http://web.fuguang.raysog.com/all_txt_"+thcon,cache:false,data:{class1:0},dataType:'JSON',success:function(msg){
var html2="";
//alert(htlmdlsa(msg['body'][0]['body']));
$(".confoot:eq(1)").html(htlmdlsa(msg['body'][0]['body']));
$(".confoot:eq(2)").html(htlmdlsa(msg['body'][1]['body']));
$(".confoot:eq(3)").html(htlmdlsa(msg['body'][2]['body']));
 $(".downtxt").remove();
 if(msg['down']){
 $.each(msg['down'],function(index,b){
							 
html2+='<tr class="downtxt">';
html2+='<td height="40" style=\"color:#868686; border-bottom:1px dashed #b6b6b6;\">&nbsp;&nbsp;&nbsp;'+b.name+'</td>';
html2+='<td style=\" border-bottom:1px dashed #b6b6b6;\">&nbsp;</td>';
html2+='<td align=\"center\" style=\"color:#868686; border-bottom:1px dashed #b6b6b6;\">'+b.size+'</td>';
html2+='<td style=\" border-bottom:1px dashed #b6b6b6;\">&nbsp;</td>';
html2+='<td style=\" border-bottom:1px dashed #b6b6b6;\" align=\"center\"><a href=\"'+update+b.down+'\" target=\"_blank\"><img src=\"'+public+'/images/down.png\" /></a></td>';
html2+='</tr>';

   });
}
$(".d_tit").html(msg['title']);
$(".d_des").html(msg['des']);
$(".d_pic").attr('src',update+msg['pic'][0]['pic']);
 $(".confoot :eq(0)").append(html2);

 
},error:function(){//alert("");
}


})
 
	
	}


//allshow();


