google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawStuff1);
google.charts.setOnLoadCallback(drawStuff2);
google.charts.setOnLoadCallback(drawStuff3);
google.charts.setOnLoadCallback(drawStuff4);
google.charts.setOnLoadCallback(drawStuff5);

function drawStuff1() {
    var data = new google.visualization.arrayToDataTable([
             [' ', ''],
      ["1", 1],
      ["2", 8],
      ["3", 7],
      ["4", 4],
      ["5", 8],
      ["6", 10],
      ["7", 3],
      ["8", 10],
      ["9", 3],
      ["10", 3],
    ]);

    var options = {
        title: '',
        width: 900,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'top', label: 'preferences' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-1'));
    // Convert the Classic options to Material options.
        chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

function drawStuff2() {
    var data = new google.visualization.arrayToDataTable([
             [' ', ''],
      ["1", 1],
      ["2", 8],
      ["3", 7],
      ["4", 4],
      ["5", 8],
      ["6", 1],
      ["7", 3],
      ["8", 1],
      ["9", 3],
      ["10", 3],
    ]);

    var options = {
        title: '',
        width: 900,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'top', label: 'preferences' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-2'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

function drawStuff3() {
    var data = new google.visualization.arrayToDataTable([
             [' ', ''],
      ["1", 1],
      ["2", 8],
      ["3", 1],
      ["4", 4],
      ["5", 8],
      ["6", 1],
      ["7", 3],
      ["8", 10],
      ["9", 3],
      ["10", 3],
    ]);

    var options = {
        title: '',
        width: 900,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'top', label: 'preferences' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-3'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

function drawStuff4() {
    var data = new google.visualization.arrayToDataTable([
            [' ', ''],
      ["1", 8],
      ["2", 8],
      ["3", 7],
      ["4", 4],
      ["5", 8],
      ["6", 1],
      ["7", 3],
      ["8", 10],
      ["9", 3],
      ["10", 3],            
    ]);

    var options = {
        title: '',
        width: 900,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'top', label: 'preferences' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-4'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

function drawStuff5() {
var data = new google.visualization.arrayToDataTable([
               [' ', ''],
      ["1", 8],
      ["2", 8],
      ["3", 7],
      ["4", 4],
      ["5", 8],
      ["6", 1],
      ["7", 3],
      ["8", 10],
      ["9", 3],
      ["10", 3],
]);

    var options = {
        title: '',
        width: 900,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'top', label: 'preferences' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

var chart = new google.charts.Bar(document.getElementById('upp-chart-5'));
// Convert the Classic options to Material options.
chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................