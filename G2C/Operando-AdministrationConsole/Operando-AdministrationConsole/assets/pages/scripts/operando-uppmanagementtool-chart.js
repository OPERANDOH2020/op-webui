//google.charts.load('current', { 'packages': ['bar'] });
//google.charts.setOnLoadCallback(drawStuff1);
//google.charts.setOnLoadCallback(drawStuff2);
//google.charts.setOnLoadCallback(drawStuff3);
//google.charts.setOnLoadCallback(drawStuff4);
//google.charts.setOnLoadCallback(drawStuff5);

//function drawStuff1() {
//    var data = new google.visualization.arrayToDataTable([
//             [' ', ''],
//      ["1", 1],
//      ["2", 8],
//      ["3", 7],
//      ["4", 4],
//      ["5", 8],
//      ["6", 10],
//      ["7", 3],
//      ["8", 10],
//      ["9", 3],
//      ["10", 3],
//    ]);

//    var options = {
//        title: '',
//        width: 900,
//        legend: { position: 'none' },
//        chart: { subtitle: 'none' },
//        axes: {
//            x: {
//                0: { side: 'top', label: 'preferences' } // Top x-axis.
//            }
//        },
//        bar: { groupWidth: "40%" }
//    };

//    var chart = new google.charts.Bar(document.getElementById('upp-chart-1'));
//    // Convert the Classic options to Material options.
//        chart.draw(data, google.charts.Bar.convertOptions(options));
//};

//// ..............................................................

//function drawStuff2() {
//    var data = new google.visualization.arrayToDataTable([
//             [' ', ''],
//      ["1", 1],
//      ["2", 8],
//      ["3", 7],
//      ["4", 4],
//      ["5", 8],
//      ["6", 1],
//      ["7", 3],
//      ["8", 1],
//      ["9", 3],
//      ["10", 3],
//    ]);

//    var options = {
//        title: '',
//        width: 900,
//        legend: { position: 'none' },
//        chart: { subtitle: 'none' },
//        axes: {
//            x: {
//                0: { side: 'top', label: 'preferences' } // Top x-axis.
//            }
//        },
//        bar: { groupWidth: "40%" }
//    };

//    var chart = new google.charts.Bar(document.getElementById('upp-chart-2'));
//    // Convert the Classic options to Material options.
//    chart.draw(data, google.charts.Bar.convertOptions(options));
//};

//// ..............................................................

//function drawStuff3() {
//    var data = new google.visualization.arrayToDataTable([
//             [' ', ''],
//      ["1", 1],
//      ["2", 8],
//      ["3", 1],
//      ["4", 4],
//      ["5", 8],
//      ["6", 1],
//      ["7", 3],
//      ["8", 10],
//      ["9", 3],
//      ["10", 3],
//    ]);

//    var options = {
//        title: '',
//        width: 900,
//        legend: { position: 'none' },
//        chart: { subtitle: 'none' },
//        axes: {
//            x: {
//                0: { side: 'top', label: 'preferences' } // Top x-axis.
//            }
//        },
//        bar: { groupWidth: "40%" }
//    };

//    var chart = new google.charts.Bar(document.getElementById('upp-chart-3'));
//    // Convert the Classic options to Material options.
//    chart.draw(data, google.charts.Bar.convertOptions(options));
//};

//// ..............................................................

//function drawStuff4() {
//    var data = new google.visualization.arrayToDataTable([
//            [' ', ''],
//      ["1", 8],
//      ["2", 8],
//      ["3", 7],
//      ["4", 4],
//      ["5", 8],
//      ["6", 1],
//      ["7", 3],
//      ["8", 10],
//      ["9", 3],
//      ["10", 3],            
//    ]);

//    var options = {
//        title: '',
//        width: 900,
//        legend: { position: 'none' },
//        chart: { subtitle: 'none' },
//        axes: {
//            x: {
//                0: { side: 'top', label: 'preferences' } // Top x-axis.
//            }
//        },
//        bar: { groupWidth: "40%" }
//    };

//    var chart = new google.charts.Bar(document.getElementById('upp-chart-4'));
//    // Convert the Classic options to Material options.
//    chart.draw(data, google.charts.Bar.convertOptions(options));
//};

//// ..............................................................

//function drawStuff5() {
//var data = new google.visualization.arrayToDataTable([
//               [' ', ''],
//      ["1", 8],
//      ["2", 8],
//      ["3", 7],
//      ["4", 4],
//      ["5", 8],
//      ["6", 1],
//      ["7", 3],
//      ["8", 10],
//      ["9", 3],
//      ["10", 3],
//]);

//    var options = {
//        title: '',
//        width: 900,
//        legend: { position: 'none' },
//        chart: { subtitle: 'none' },
//        axes: {
//            x: {
//                0: { side: 'top', label: 'preferences' } // Top x-axis.
//            }
//        },
//        bar: { groupWidth: "40%" }
//    };

//var chart = new google.charts.Bar(document.getElementById('upp-chart-5'));
//// Convert the Classic options to Material options.
//chart.draw(data, google.charts.Bar.convertOptions(options));
//};

//// ..............................................................

var chart = AmCharts.makeChart("chartdiv1", {
    "type": "serial",
    "theme": "none",
    "dataProvider": [{
        "value": "1",
        "number": 2025
    }, {
        "value": "2",
        "number": 1882
    }, {
        "value": "3",
        "number": 1809
    }, {
        "value": "4",
        "number": 1322
    }, {
        "value": "5",
        "number": 1122
    }, {
        "value": "6",
        "number": 1114
    }, {
        "value": "7",
        "number": 984
    }, {
        "value": "8",
        "number": 711
    }, {
        "value": "9",
        "number": 665
    }, {
        "value": "10",
        "number": 580
    }, ],
    "valueAxes": [{
        "gridColor": "#FFFFFF",
        "gridAlpha": 0.2,
        "dashLength": 0
    }],
    "gridAboveGraphs": true,
    "startDuration": 1,
    "graphs": [{
        "balloonText": "[[category]]: <b>[[value]]</b>",
        "fillAlphas": 0.8,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "number"
    }],
    "chartCursor": {
        "categoryBalloonEnabled": false,
        "cursorAlpha": 0,
        "zoomable": false
    },
    "categoryField": "value",
    "categoryAxis": {
        "gridPosition": "start",
        "gridAlpha": 0,
        "tickPosition": "start",
        "tickLength": 20
    },
    "export": {
        "enabled": true
    }

});

// --------------------------------------------------------

var chart = AmCharts.makeChart("chartdiv2", {
    "type": "serial",
    "theme": "none",
    "dataProvider": [{
        "country": "1",
        "visits": 25
    }, {
        "country": "2",
        "visits": 1882
    }, {
        "country": "3",
        "visits": 809
    }, {
        "country": "4",
        "visits": 322
    }, {
        "country": "5",
        "visits": 22
    }, {
        "country": "6",
        "visits": 1114
    }, {
        "country": "7",
        "visits": 84
    }, {
        "country": "8",
        "visits": 711
    }, {
        "country": "9",
        "visits": 665
    }, {
        "country": "10",
        "visits": 580
    }, ],
    "valueAxes": [{
        "gridColor": "#FFFFFF",
        "gridAlpha": 0.2,
        "dashLength": 0
    }],
    "gridAboveGraphs": true,
    "startDuration": 1,
    "graphs": [{
        "balloonText": "[[category]]: <b>[[value]]</b>",
        "fillAlphas": 0.8,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "visits"
    }],
    "chartCursor": {
        "categoryBalloonEnabled": false,
        "cursorAlpha": 0,
        "zoomable": false
    },
    "categoryField": "country",
    "categoryAxis": {
        "gridPosition": "start",
        "gridAlpha": 0,
        "tickPosition": "start",
        "tickLength": 20
    },
    "export": {
        "enabled": true
    }

});

// --------------------------------------------------------

var chart = AmCharts.makeChart("chartdiv3", {
    "type": "serial",
    "theme": "none",
    "dataProvider": [{
        "country": "1",
        "visits": 25
    }, {
        "country": "2",
        "visits": 182
    }, {
        "country": "3",
        "visits": 809
    }, {
        "country": "4",
        "visits": 122
    }, {
        "country": "5",
        "visits": 22
    }, {
        "country": "6",
        "visits": 1114
    }, {
        "country": "7",
        "visits": 84
    }, {
        "country": "8",
        "visits": 711
    }, {
        "country": "9",
        "visits": 665
    }, {
        "country": "10",
        "visits": 580
    }, ],
    "valueAxes": [{
        "gridColor": "#FFFFFF",
        "gridAlpha": 0.2,
        "dashLength": 0
    }],
    "gridAboveGraphs": true,
    "startDuration": 1,
    "graphs": [{
        "balloonText": "[[category]]: <b>[[value]]</b>",
        "fillAlphas": 0.8,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "visits"
    }],
    "chartCursor": {
        "categoryBalloonEnabled": false,
        "cursorAlpha": 0,
        "zoomable": false
    },
    "categoryField": "country",
    "categoryAxis": {
        "gridPosition": "start",
        "gridAlpha": 0,
        "tickPosition": "start",
        "tickLength": 20
    },
    "export": {
        "enabled": true
    }

});

// --------------------------------------------------------

var chart = AmCharts.makeChart("chartdiv4", {
    "type": "serial",
    "theme": "none",
    "dataProvider": [{
        "country": "1",
        "visits": 25
    }, {
        "country": "2",
        "visits": 182
    }, {
        "country": "3",
        "visits": 109
    }, {
        "country": "4",
        "visits": 132
    }, {
        "country": "5",
        "visits": 22
    }, {
        "country": "6",
        "visits": 1114
    }, {
        "country": "7",
        "visits": 84
    }, {
        "country": "8",
        "visits": 711
    }, {
        "country": "9",
        "visits": 665
    }, {
        "country": "10",
        "visits": 580
    }, ],
    "valueAxes": [{
        "gridColor": "#FFFFFF",
        "gridAlpha": 0.2,
        "dashLength": 0
    }],
    "gridAboveGraphs": true,
    "startDuration": 1,
    "graphs": [{
        "balloonText": "[[category]]: <b>[[value]]</b>",
        "fillAlphas": 0.8,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "visits"
    }],
    "chartCursor": {
        "categoryBalloonEnabled": false,
        "cursorAlpha": 0,
        "zoomable": false
    },
    "categoryField": "country",
    "categoryAxis": {
        "gridPosition": "start",
        "gridAlpha": 0,
        "tickPosition": "start",
        "tickLength": 20
    },
    "export": {
        "enabled": true
    }

});

// --------------------------------------------------------

var chart = AmCharts.makeChart("chartdiv5", {
    "type": "serial",
    "theme": "none",
    "dataProvider": [{
        "country": "1",
        "visits": 25
    }, {
        "country": "2",
        "visits": 882
    }, {
        "country": "3",
        "visits": 809
    }, {
        "country": "4",
        "visits": 1322
    }, {
        "country": "5",
        "visits": 22
    }, {
        "country": "6",
        "visits": 114
    }, {
        "country": "7",
        "visits": 84
    }, {
        "country": "8",
        "visits": 711
    }, {
        "country": "9",
        "visits": 665
    }, {
        "country": "10",
        "visits": 580
    }, ],
    "valueAxes": [{
        "gridColor": "#FFFFFF",
        "gridAlpha": 0.2,
        "dashLength": 0
    }],
    "gridAboveGraphs": true,
    "startDuration": 1,
    "graphs": [{
        "balloonText": "[[category]]: <b>[[value]]</b>",
        "fillAlphas": 0.8,
        "lineAlpha": 0.2,
        "type": "column",
        "valueField": "visits"
    }],
    "chartCursor": {
        "categoryBalloonEnabled": false,
        "cursorAlpha": 0,
        "zoomable": false
    },
    "categoryField": "country",
    "categoryAxis": {
        "gridPosition": "start",
        "gridAlpha": 0,
        "tickPosition": "start",
        "tickLength": 20
    },
    "export": {
        "enabled": true
    }

});