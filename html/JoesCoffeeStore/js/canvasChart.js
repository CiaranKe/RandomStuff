var coffeeSales = [];
coffeeSales[0] = "Jan,170";
coffeeSales[1] = "Feb,320";
coffeeSales[2] = "Mar,432";
coffeeSales[3] = "Apr,548";
coffeeSales[4] = "May,342";
coffeeSales[5] = "Jun,689";
coffeeSales[6] = "Jul,344";
coffeeSales[7] = "Aug,109";
coffeeSales[8] = "Sep,655";
coffeeSales[9] = "Oct,327";
coffeeSales[10] = "Nov,109";
coffeeSales[11] = "Dec,235";

function createAxis(context, startX, startY, endX, endY)
{
    context.beginPath();
    context.moveTo(startX,startY);
    context.lineTo(endX,endY);
    context.closePath();
    context.stroke();
}

function createBar(context, x, y, width, height)
{
    context.beginPath();
    context.rect(x,y,width,height);
    context.closePath();
    context.stroke();
    context.fill();
}

function createBarChart(context, data, startX, barWidth, chartHeight)
{
    context.lineWidth = '1.2';
    var startY = 780;
    createAxis(context, startX, startY,startX, 30); //vertical
    createAxis(context, startX, startY, 650, startY); //horizontal
    var maxValue = 0;
    context.lineWidth = '0.0';
    for (var i = 0; i < data.length; i++)
    {
        var item = data[i].split(",");
        var itemName = item[0];
        var itemValue = parseInt(item[1]);
        if(parseInt(itemValue) > parseInt(maxValue))
        {
            maxValue = itemValue;
        }
        context.fillStyle = 'blue';
        createBar(context, 20 + startX + (i * barWidth) + i + (i *30 ), (chartHeight - itemValue), 50, itemValue);
        context.textAlign ='left';
        context.fillStyle = 'black';
        context.fillText(itemValue, 20 + startX + (i * barWidth) + i + (i * 30) + 10, chartHeight - itemValue - 5);
        context.fillText(itemName, 20 + startX + (i * barWidth) + i + (i * 30) + 10, chartHeight + 15);
    }
}

function drawChart()
{
    var canvas = document.getElementById('barChart');
    var context = canvas.getContext('2d');
    createBarChart(context, coffeeSales, 30,20,(canvas.height - 20), 50);
}