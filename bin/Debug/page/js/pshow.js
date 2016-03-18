$(function(){
	pssublen=$(".pssub").length;
	if(pssublen){
		mrssc=$(".pssub").eq(0).attr('s');
		$(".showimg").attr("src",mrssc);
		$(".showimg").width("280px");
$(".showimg").load(function(){
	img_px(".showimg",280,280);		
	
}); 

		
		}

var divsl=$(".wcn2 li").length*72;
$(".wcn2").width(divsl+300);
var allcontent2=($(".wcn2").width()-$(".wc2").width())/100;
var wc2=$(".wc2").offset().left;
var mr2=$(".mr2").offset().left;
$(".wc2").mousemove(function(e){
$(".wcn2").animate({left: '-'+(((e.pageX-wc2)/((mr2-wc2)/100))*allcontent2)+'px'}, 0);

});



$(".pssub").click(function(){
$(".pssub").parent().css({"border":"1px solid #cccccc"})
$(this).parent().css({"border":"2px solid red"});
var s1=$(this).attr("src");
var s2=$(this).attr("s");
$(".showimg").attr("src",s2);
img_px(".showimg",280,280);
//$(".jqzoom").attr("href",s2);

});



$(".ls1dh").click(function(){
$(".ls1dh").removeClass("ths");
$(this).addClass("ths");

var cshw=$(this).attr("show");
$(".cshow").hide();
$(".content"+cshw).show();
})
 })



		   
