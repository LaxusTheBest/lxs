var t;
var i;
var moveInterval = 2288;
var timerInterval = 80;
var timeRest = 0;
var wasPaused = false;
var pages = ["First.html","Second.html","Third.html"];
var pNumber  = Number(document.getElementById("nPage").textContent);

function prevPage(){
	history.back();
}

function start() {
	t = setTimeout(nextPage,moveInterval);
    i = setInterval(changeTimer, timerInterval);
}

function changeTimer() {
    if (timeRest <= 0)
        timeRest = moveInterval;
    timeRest = timeRest - timerInterval;
    document.getElementById("timeleft").innerHTML = "Next pages in " + ((timeRest) / 1000) + " ";
}

function nextPage(){

	if(pNumber - 1 == pages.length-1){
		if(confirm("Repeat?")){
			window.location = pages[0];
		}
		else
		{ 
			try{
                self.close();
                alert("Impossible to close window");
                pasue();
            }
            catch(er){

                alert("Closing window error");
            }
        }
	}
	else{
		window.location = pages[pNumber];
	}
}

function pause(){
	if(wasPaused) 
		{ 
			wasPaused = false; 
			timeRest = 0;
			start(); 
		}
	else{
		clearTimeout(t);
		clearInterval(i);
		wasPaused = true;
	}
	
}
start();