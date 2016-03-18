var timetxt = 31;

function timedCount(){
	timetxt--;
	postMessage(timetxt);
	setTimeout("timedCount()",1000);
}

timedCount();