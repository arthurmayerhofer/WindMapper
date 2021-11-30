
$(function () {

    //var palette = paletteGenerator(colorBar);
    var palette = colorBar;

    ajax_chart("Rose", "/windrose/getdata", 1, palette);
    ajax_chart("Rose2", "/windrose/getdata", 2, palette);

    setInterval(function () {

        ajax_chart("Rose", "/windrose/getdata");
        ajax_chart("Rose2", "/windrose/getdata");

    }, 10000);
});

// function to update our chart
function ajax_chart(plotly, url, select, palette) {

    $.getJSON(url).done(function (response) {

        var legend = [];
        var resposta = [];
        var titleChart;
        var suffix = 2;
        var tick;

        //select == 1 ? resposta = response.item1 : resposta = response.item2;
        //select == 1 ? legend = legendVelocity : legend = legendDirection;

        if (select == 1)
        {
            resposta = response.item1;
            legend = legendVelocity;
            titleChart = "Distribuição de Velocidade do Vento";
            suffix = "m/s";
        }
        else
        {
            resposta = response.item2;
            legend = legendDirection;
            titleChart = "Distribuição de Direção do Vento";
            suffix = "%";
        }

        var data = createData(resposta, palette, legend);

        var layout = {
            title: titleChart,
            width: 1000,
            height: 850,
            font: { size: 16 },
            legend: { font: { size: 16 } },
            colorbar: { thickness: 10, len: 20 },

            polar: {
                barmode: "group",
                bargap: 0,
                radialaxis: { ticksuffix: suffix, angle: 45, dtick: tick},
                angularaxis: { direction: "clockwise" },
            }
        }

        Plotly.newPlot(plotly, data, layout);
    });
}

const angles = [
    'N', '10', '20', '30', '40', '50', '60', '70', '80',
    'L', '100', '110', '120', '130', '140', '150', '160', '170',
    'S', '190', '200', '210', '220', '230', '240', '250', '260',
    'O', '280', '290','300', '310', '320', '330', '340','350'
    ];

const legendVelocity = [
    "0 - 0.5 m/s", "0.5 - 1 m/s", "1 - 1.5 m/s", "1.5 - 2 m/s", "2 - 2.5 m/s", "2.5 - 3 m/s", "3 - 3.5 m/s", ">= 3.5 m/s"
];

const legendDirection = [
    "0 - 1%", "1 - 2%", "2 - 3%", "3 - 4%", "4 - 5%", "5 - 6%", "5 - 6%", ">= 7%"
];

const colorBar = "rgb(100,15,15)";

function paletteGenerator(color) {

    var colorSplit = color.split(',');
    const palette = [];
    let g = parseInt(colorSplit[1]);
    let b = parseInt(colorSplit[2]);
    let a = 20;

    for (var i = 0; i <= 7; i++) {
        b += a;
        g += a;
        var str = colorSplit[0] + ',' + g.toString() + ',' + b.toString() + ')';
        palette.push(str);
    }
    return palette;
}


function createData(resposta, palette, legend) {

    var dataList = [];
    dataList.push({ r: [0.], theta: ["N"], name: "Legenda", marker: { color: "rgb(255,255,255)" }, type: "barpolar" });

    for (var i = 0; i <= 7; i++) {

        var _marker = { color: palette[i] };
        var barData = { r: resposta[i], theta: angles, name: legend[i], marker: _marker, type: "barpolar" };
        dataList.push(barData);
    }

    return dataList;
}
     
