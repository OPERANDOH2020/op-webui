google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawStuff1);
google.charts.setOnLoadCallback(drawStuff2);
google.charts.setOnLoadCallback(drawStuff3);
google.charts.setOnLoadCallback(drawStuff4);
google.charts.setOnLoadCallback(drawStuff5);

function drawStuff1() {
    var data = new google.visualization.arrayToDataTable([
      ['1', 'Percentage'],
      ["2", 44],
      ["3", 31],
      ["4", 12],
      ["5", 10],
      ['6', 3],
      ['7', 3],
      ['8', 3],
      ['9', 3],
      ['10', 3],
    ]);

    var options = {
        title: '',
        width: 900,
        height: 300,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'bottom', label: ''} // Top x-axis.
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
      ['1', 'Percentage'],
      ["2", 44],
      ["3", 31],
      ["4", 12],
      ["5", 10],
      ['6', 3],
      ['7', 3],
      ['8', 3],
      ['9', 3],
      ['10', 3],
    ]);

    var options = {
        title: '',
        width: 900,
        height: 300,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'bottom', label: '' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-1'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

function drawStuff3() {
    var data = new google.visualization.arrayToDataTable([
       ['1', 'Percentage'],
       ["2", 44],
       ["3", 31],
       ["4", 12],
       ["5", 10],
       ['6', 3],
       ['7', 3],
       ['8', 3],
       ['9', 3],
       ['10', 3],
    ]);

    var options = {
        title: '',
        width: 900,
        height: 300,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'bottom', label: '' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-1'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

function drawStuff4() {
    var data = new google.visualization.arrayToDataTable([
       ['1', 'Percentage'],
       ["2", 44],
       ["3", 31],
       ["4", 12],
       ["5", 10],
       ['6', 3],
       ['7', 3],
       ['8', 3],
       ['9', 3],
       ['10', 3],
    ]);

    var options = {
        title: '',
        width: 900,
        height: 300,
        legend: { position: 'none' },
        chart: { subtitle: 'none' },
        axes: {
            x: {
                0: { side: 'bottom', label: '' } // Top x-axis.
            }
        },
        bar: { groupWidth: "40%" }
    };

    var chart = new google.charts.Bar(document.getElementById('upp-chart-1'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................

var data = new google.visualization.arrayToDataTable([
      ['1', 'Percentage'],
      ["2", 44],
      ["3", 31],
      ["4", 12],
      ["5", 10],
      ['6', 3],
      ['7', 3],
      ['8', 3],
      ['9', 3],
      ['10', 3],
]);

var options = {
    title: '',
    width: 900,
    height: 300,
    legend: { position: 'none' },
    chart: { subtitle: 'none' },
    axes: {
        x: {
            0: { side: 'bottom', label: ''} // Top x-axis.
        }
    },
    bar: { groupWidth: "40%" }
};

var chart = new google.charts.Bar(document.getElementById('upp-chart-1'));
// Convert the Classic options to Material options.
chart.draw(data, google.charts.Bar.convertOptions(options));
};

// ..............................................................