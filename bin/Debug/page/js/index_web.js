$(function(){
		
pshowsl=$(".prshow").size();
pshowwd=$(".prshow").eq(0).width();
$(".idpshow").width((pshowsl*pshowwd));


$(".pright").click(function(){
	leftshow();		
 });
$(".pleft").click(function(){	 
	 rightshow();				   
 });

$(".pleft").hover(function(){
	var src2=$(this).attr("src2");	
	$(this).attr('src',src2);
 },function(){
	 var src1=$(this).attr("src1");	
	$(this).attr('src',src1);
	 });

$(".pright").hover(function(){
	var src2=$(this).attr("src2");	
	$(this).attr('src',src2);
 },function(){
	 var src1=$(this).attr("src1");	
	$(this).attr('src',src1);
	 });



});


   
function leftshow(){
	//alert(parseInt($(".idpshow").css("margin-left")));
	if((parseInt($(".idpshow").css("margin-left"))+(-840))>(-parseInt($(".idpshow").width()))){
$(".idpshow").animate({marginLeft: '-=' + 840}, 400);
		}else{
			rightshow();
			};
}
	
function rightshow(){
	if(parseInt($(".idpshow").css("margin-left"))>=0){
		leftshow();
		}else{
	$(".idpshow").animate({marginLeft: '+=' + 840}, 400);
	}
}
		