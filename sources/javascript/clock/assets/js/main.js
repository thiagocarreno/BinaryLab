function setupNumbers(){
    var numbers = new Array(10);
    
    for(var i = 0; i < numbers.length; i++){
        numbers[i] = new Array(5) ;
        for(var j = 0; j < numbers[i].length; j++){
            numbers[i][j] = new Array(7) ;
        }
    }
    /*--------------------------------------------------------------------------------------ZERO------------------------------------------------------------------------------------------------*/
    numbers[0][0][0]  = 0;	numbers[0][0][1] = 1;	numbers[0][0][2] = 1;	numbers[0][0][3] = 1;	numbers[0][0][4] = 1;	numbers[0][0][5] = 1;	numbers[0][0][6] = 0;
    numbers[0][1][0]  = 0;	numbers[0][1][1] = 1;	numbers[0][1][2] = 0;	numbers[0][1][3] = 0;	numbers[0][1][4] = 0;	numbers[0][1][5] = 1;	numbers[0][1][6] = 0;
    numbers[0][2][0]  = 0;	numbers[0][2][1] = 1;	numbers[0][2][2] = 0;	numbers[0][2][3] = 0;	numbers[0][2][4] = 0;	numbers[0][2][5] = 1;	numbers[0][2][6] = 0;
    numbers[0][3][0]  = 0;	numbers[0][3][1] = 1;	numbers[0][3][2] = 0;	numbers[0][3][3] = 0;	numbers[0][3][4] = 0;	numbers[0][3][5] = 1;	numbers[0][3][6] = 0;
    numbers[0][4][0]  = 0;	numbers[0][4][1] = 1;	numbers[0][4][2] = 1;	numbers[0][4][3] = 1;	numbers[0][4][4] = 1;	numbers[0][4][5] = 1;	numbers[0][4][6] = 0;
    /*--------------------------------------------------------------------------------------UM------------------------------------------------------------------------------------------------*/
    numbers[1][0][0]  = 0;	numbers[1][0][1] = 0;	numbers[1][0][2] = 0;	numbers[1][0][3] = 1;	numbers[1][0][4] = 0;	numbers[1][0][5] = 0;	numbers[1][0][6] = 0;
    numbers[1][1][0]  = 0;	numbers[1][1][1] = 0;	numbers[1][1][2] = 0;	numbers[1][1][3] = 1;	numbers[1][1][4] = 0;	numbers[1][1][5] = 0;	numbers[1][1][6] = 0;
    numbers[1][2][0]  = 0;	numbers[1][2][1] = 0;	numbers[1][2][2] = 0;	numbers[1][2][3] = 1;	numbers[1][2][4] = 0;	numbers[1][2][5] = 0;	numbers[1][2][6] = 0;
    numbers[1][3][0]  = 0;	numbers[1][3][1] = 0;	numbers[1][3][2] = 0;	numbers[1][3][3] = 1;	numbers[1][3][4] = 0;	numbers[1][3][5] = 0;	numbers[1][3][6] = 0;
    numbers[1][4][0]  = 0;	numbers[1][4][1] = 0;	numbers[1][4][2] = 0;	numbers[1][4][3] = 1;	numbers[1][4][4] = 0;	numbers[1][4][5] = 0;	numbers[1][4][6] = 0;
    /*--------------------------------------------------------------------------------------DOIS------------------------------------------------------------------------------------------------*/
    numbers[2][0][0]  = 0;	numbers[2][0][1] = 1;	numbers[2][0][2] = 1;	numbers[2][0][3] = 1;	numbers[2][0][4] = 1;	numbers[2][0][5] = 1;	numbers[2][0][6] = 0;
    numbers[2][1][0]  = 0;	numbers[2][1][1] = 0;	numbers[2][1][2] = 0;	numbers[2][1][3] = 0;	numbers[2][1][4] = 0;	numbers[2][1][5] = 1;	numbers[2][1][6] = 0;
    numbers[2][2][0]  = 0;	numbers[2][2][1] = 1;	numbers[2][2][2] = 1;	numbers[2][2][3] = 1;	numbers[2][2][4] = 1;	numbers[2][2][5] = 1;	numbers[2][2][6] = 0;
    numbers[2][3][0]  = 0;	numbers[2][3][1] = 1;	numbers[2][3][2] = 0;	numbers[2][3][3] = 0;	numbers[2][3][4] = 0;	numbers[2][3][5] = 0;	numbers[2][3][6] = 0;
    numbers[2][4][0]  = 0;	numbers[2][4][1] = 1;	numbers[2][4][2] = 1;	numbers[2][4][3] = 1;	numbers[2][4][4] = 1;	numbers[2][4][5] = 1;	numbers[2][4][6] = 0;
    /*--------------------------------------------------------------------------------------TRES------------------------------------------------------------------------------------------------*/
    numbers[3][0][0]  = 0;	numbers[3][0][1] = 1;	numbers[3][0][2] = 1;	numbers[3][0][3] = 1;	numbers[3][0][4] = 1;	numbers[3][0][5] = 1;	numbers[3][0][6] = 0;
    numbers[3][1][0]  = 0;	numbers[3][1][1] = 0;	numbers[3][1][2] = 0;	numbers[3][1][3] = 0;	numbers[3][1][4] = 0;	numbers[3][1][5] = 1;	numbers[3][1][6] = 0;
    numbers[3][2][0]  = 0;	numbers[3][2][1] = 1;	numbers[3][2][2] = 1;	numbers[3][2][3] = 1;	numbers[3][2][4] = 1;	numbers[3][2][5] = 1;	numbers[3][2][6] = 0;
    numbers[3][3][0]  = 0;	numbers[3][3][1] = 0;	numbers[3][3][2] = 0;	numbers[3][3][3] = 0;	numbers[3][3][4] = 0;	numbers[3][3][5] = 1;	numbers[3][3][6] = 0;
    numbers[3][4][0]  = 0;	numbers[3][4][1] = 1;	numbers[3][4][2] = 1;	numbers[3][4][3] = 1;	numbers[3][4][4] = 1;	numbers[3][4][5] = 1;	numbers[3][4][6] = 0;
    /*--------------------------------------------------------------------------------------QUATRO------------------------------------------------------------------------------------------------*/
    numbers[4][0][0]  = 0;	numbers[4][0][1] = 1;	numbers[4][0][2] = 0;	numbers[4][0][3] = 0;	numbers[4][0][4] = 0;	numbers[4][0][5] = 1;	numbers[4][0][6] = 0;
    numbers[4][1][0]  = 0;	numbers[4][1][1] = 1;	numbers[4][1][2] = 0;	numbers[4][1][3] = 0;	numbers[4][1][4] = 0;	numbers[4][1][5] = 1;	numbers[4][1][6] = 0;
    numbers[4][2][0]  = 0;	numbers[4][2][1] = 1;	numbers[4][2][2] = 1;	numbers[4][2][3] = 1;	numbers[4][2][4] = 1;	numbers[4][2][5] = 1;	numbers[4][2][6] = 0;
    numbers[4][3][0]  = 0;	numbers[4][3][1] = 0;	numbers[4][3][2] = 0;	numbers[4][3][3] = 0;	numbers[4][3][4] = 0;	numbers[4][3][5] = 1;	numbers[4][3][6] = 0;
    numbers[4][4][0]  = 0;	numbers[4][4][1] = 0;	numbers[4][4][2] = 0;	numbers[4][4][3] = 0;	numbers[4][4][4] = 0;	numbers[4][4][5] = 1;	numbers[4][4][6] = 0;
    /*--------------------------------------------------------------------------------------CINCO------------------------------------------------------------------------------------------------*/
    numbers[5][0][0]  = 0;	numbers[5][0][1] = 1;	numbers[5][0][2] = 1;	numbers[5][0][3] = 1;	numbers[5][0][4] = 1;	numbers[5][0][5] = 1;	numbers[5][0][6] = 0;
    numbers[5][1][0]  = 0;	numbers[5][1][1] = 1;	numbers[5][1][2] = 0;	numbers[5][1][3] = 0;	numbers[5][1][4] = 0;	numbers[5][1][5] = 0;	numbers[5][1][6] = 0;
    numbers[5][2][0]  = 0;	numbers[5][2][1] = 1;	numbers[5][2][2] = 1;	numbers[5][2][3] = 1;	numbers[5][2][4] = 1;	numbers[5][2][5] = 1;	numbers[5][2][6] = 0;
    numbers[5][3][0]  = 0;	numbers[5][3][1] = 0;	numbers[5][3][2] = 0;	numbers[5][3][3] = 0;	numbers[5][3][4] = 0;	numbers[5][3][5] = 1;	numbers[5][3][6] = 0;
    numbers[5][4][0]  = 0;	numbers[5][4][1] = 1;	numbers[5][4][2] = 1;	numbers[5][4][3] = 1;	numbers[5][4][4] = 1;	numbers[5][4][5] = 1;	numbers[5][4][6] = 0;
    /*--------------------------------------------------------------------------------------SEIS------------------------------------------------------------------------------------------------*/
    numbers[6][0][0]  = 0;	numbers[6][0][1] = 1;	numbers[6][0][2] = 1;	numbers[6][0][3] = 1;	numbers[6][0][4] = 1;	numbers[6][0][5] = 1;	numbers[6][0][6] = 0;
    numbers[6][1][0]  = 0;	numbers[6][1][1] = 1;	numbers[6][1][2] = 0;	numbers[6][1][3] = 0;	numbers[6][1][4] = 0;	numbers[6][1][5] = 0;	numbers[6][1][6] = 0;
    numbers[6][2][0]  = 0;	numbers[6][2][1] = 1;	numbers[6][2][2] = 1;	numbers[6][2][3] = 1;	numbers[6][2][4] = 1;	numbers[6][2][5] = 1;	numbers[6][2][6] = 0;
    numbers[6][3][0]  = 0;	numbers[6][3][1] = 1;	numbers[6][3][2] = 0;	numbers[6][3][3] = 0;	numbers[6][3][4] = 0;	numbers[6][3][5] = 1;	numbers[6][3][6] = 0;
    numbers[6][4][0]  = 0;	numbers[6][4][1] = 1;	numbers[6][4][2] = 1;	numbers[6][4][3] = 1;	numbers[6][4][4] = 1;	numbers[6][4][5] = 1;	numbers[6][4][6] = 0;
    /*--------------------------------------------------------------------------------------SETE------------------------------------------------------------------------------------------------*/
    numbers[7][0][0]  = 0;	numbers[7][0][1] = 1;	numbers[7][0][2] = 1;	numbers[7][0][3] = 1;	numbers[7][0][4] = 1;	numbers[7][0][5] = 1;	numbers[7][0][6] = 0;
    numbers[7][1][0]  = 0;	numbers[7][1][1] = 1;	numbers[7][1][2] = 0;	numbers[7][1][3] = 0;	numbers[7][1][4] = 0;	numbers[7][1][5] = 1;	numbers[7][1][6] = 0;
    numbers[7][2][0]  = 0;	numbers[7][2][1] = 0;	numbers[7][2][2] = 0;	numbers[7][2][3] = 0;	numbers[7][2][4] = 0;	numbers[7][2][5] = 1;	numbers[7][2][6] = 0;
    numbers[7][3][0]  = 0;	numbers[7][3][1] = 0;	numbers[7][3][2] = 0;	numbers[7][3][3] = 0;	numbers[7][3][4] = 0;	numbers[7][3][5] = 1;	numbers[7][3][6] = 0;
    numbers[7][4][0]  = 0;	numbers[7][4][1] = 0;	numbers[7][4][2] = 0;	numbers[7][4][3] = 0;	numbers[7][4][4] = 0;	numbers[7][4][5] = 1;	numbers[7][4][6] = 0;
    /*--------------------------------------------------------------------------------------OITO------------------------------------------------------------------------------------------------*/
    numbers[8][0][0]  = 0;	numbers[8][0][1] = 1;	numbers[8][0][2] = 1;	numbers[8][0][3] = 1;	numbers[8][0][4] = 1;	numbers[8][0][5] = 1;	numbers[8][0][6] = 0;
    numbers[8][1][0]  = 0;	numbers[8][1][1] = 1;	numbers[8][1][2] = 0;	numbers[8][1][3] = 0;	numbers[8][1][4] = 0;	numbers[8][1][5] = 1;	numbers[8][1][6] = 0;
    numbers[8][2][0]  = 0;	numbers[8][2][1] = 1;	numbers[8][2][2] = 1;	numbers[8][2][3] = 1;	numbers[8][2][4] = 1;	numbers[8][2][5] = 1;	numbers[8][2][6] = 0;
    numbers[8][3][0]  = 0;	numbers[8][3][1] = 1;	numbers[8][3][2] = 0;	numbers[8][3][3] = 0;	numbers[8][3][4] = 0;	numbers[8][3][5] = 1;	numbers[8][3][6] = 0;
    numbers[8][4][0]  = 0;	numbers[8][4][1] = 1;	numbers[8][4][2] = 1;	numbers[8][4][3] = 1;	numbers[8][4][4] = 1;	numbers[8][4][5] = 1;	numbers[8][4][6] = 0;
    /*--------------------------------------------------------------------------------------NOVE------------------------------------------------------------------------------------------------*/
    numbers[9][0][0]  = 0;	numbers[9][0][1] = 1;	numbers[9][0][2] = 1;	numbers[9][0][3] = 1;	numbers[9][0][4] = 1;	numbers[9][0][5] = 1;	numbers[9][0][6] = 0;
    numbers[9][1][0]  = 0;	numbers[9][1][1] = 1;	numbers[9][1][2] = 0;	numbers[9][1][3] = 0;	numbers[9][1][4] = 0;	numbers[9][1][5] = 1;	numbers[9][1][6] = 0;
    numbers[9][2][0]  = 0;	numbers[9][2][1] = 1;	numbers[9][2][2] = 1;	numbers[9][2][3] = 1;	numbers[9][2][4] = 1;	numbers[9][2][5] = 1;	numbers[9][2][6] = 0;
    numbers[9][3][0]  = 0;	numbers[9][3][1] = 0;	numbers[9][3][2] = 0;	numbers[9][3][3] = 0;	numbers[9][3][4] = 0;	numbers[9][3][5] = 1;	numbers[9][3][6] = 0;
    numbers[9][4][0]  = 0;	numbers[9][4][1] = 1;	numbers[9][4][2] = 1;	numbers[9][4][3] = 1;	numbers[9][4][4] = 1;	numbers[9][4][5] = 1;	numbers[9][4][6] = 0;
    
    return numbers;
}

function printAllNumbers(numbers) {

    for(var i=0; i < numbers.length; i++){
        for(var j=0; j < numbers[i].length; j++){
            for(var k=0; k < numbers[i][j].length; k++){
                document.write(numbers[i][j][k]);
            }
            document.write('<br />');
        }
        document.write('<br />');
    }
    
}

function setupMatrix() {
    var matrix = new Array(5);
    
    for(var i=0; i < matrix.length; i++){
        matrix[i] = new Array(48);
        for(var j=0; j < matrix[i].length;  j++){
            matrix[i][j] = 0;
        }
    }
    
    matrix[1][15] = 1;
    matrix[3][15] = 1;

    matrix[1][32] = 1;
    matrix[3][32] = 1;
            
    return matrix;
}

function appendNumber(matrix, numbers, period, number){
    
    var strNumber = number.toString();
    var first = '';
    var second = '';
    
    if(strNumber.length == 1){
        strNumber = "0" + strNumber;
    }
    
    first = strNumber[0];
    second = strNumber[1];
    
    var startIndexFirst = 0;
    var startIndexSecond = 0;
    
    if(period === "hour"){
            startIndexFirst 		= 0;
            startIndexSecond 	= 7;
            
    }
    else if(period === "minute"){
            startIndexFirst 		= 17;
            startIndexSecond 	= 24;
            
    }
    else if(period === "second"){
            startIndexFirst 		= 34;
            startIndexSecond 	= 41;
    }
    else{
        console.log('error...  period unkown');
    }
    
    var indexOne = parseInt(first);
    var indexTwo = parseInt(second);
    
    for(var i = 0; i < 5; i++){
        for(var j = 0; j < 7; j++){
            matrix[i][j+startIndexFirst] = numbers[indexOne][i][j];
            matrix[i][j+startIndexSecond] = numbers[indexTwo][i][j];
        }
    }
}

function showMatrix(matrix){
    for(var i=0; i < matrix.length; i++){
        for(var j=0; j < matrix[i].length;  j++){
            document.write(matrix[i][j]);
        }
        document.write("<br />");
    }
}

function paintMatrix(matrix){
    
    for(var i=0; i < matrix.length; i++){
        var row = document.getElementsByTagName('tr')[i]; 
        
        for(var j=0; j < matrix[i].length;  j++){
            var obj = row.getElementsByTagName('td')[j];
            
            if(matrix[i][j] === 0){
                if(obj.getAttribute('class') !== 'hide'){
                    transition('hide', obj, (i+1)*(j+1)*2);
                }
            } 
            else {
                if(obj.getAttribute('class') !== 'show'){
                    transition('show', obj, (i+1)*(j+1)*2);
                }
            }
            
        }
    }
}

function transition(act, obj, delay){
    console.log('transition');
    if(act ==='hide'){
        setTimeout(function(){
            obj.setAttribute('class','hide');
        }, delay)
    } else {
        setTimeout(function(){
            obj.setAttribute('class','show');
        }, delay)
    }
}

var matrixGlobal = setupMatrix();
var numbersGlobal = setupNumbers();

function exec(){
    var matrix = matrixGlobal;
    var numbers = numbersGlobal;
    
    var date = new Date;
    var seconds 	= date.getSeconds();
    var minutes 	= date.getMinutes();
    var hour 		= date.getHours();
    
    appendNumber(matrix, numbers, "hour", 		hour);
    appendNumber(matrix, numbers, "minute", 	minutes);
    appendNumber(matrix, numbers, "second", 	seconds);
    
    paintMatrix(matrix);
}

window.setInterval(exec, 1000);