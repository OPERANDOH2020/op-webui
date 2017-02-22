google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawStuff1);
google.charts.setOnLoadCallback(drawStuff2);
google.charts.setOnLoadCallback(drawStuff3);
google.charts.setOnLoadCallback(drawStuff4);
google.charts.setOnLoadCallback(drawStuff5);

function drawStuff1() {
    var data = new google.visualization.arrayToDataTable([
      ['Recepionist', 'YES', 'NO'],
      ['Recepionist', 70, 30],
      ['Recepionist', 60, 40],
      ['Doctor', 60, 40],
      ['Doctor', 50, 50],
      ['Doctor', 50, 50]
    ]);

    var options = {
        width: 900,
        height: 500,
        chart: {
            title: '',
            subtitle: ''
        },
        series: {
            0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
        },
        axes: {
            y: {
                distance: { label: '' }, // Left y-axis.              
            }
        }
    };



    var chart1 = new google.charts.Bar(document.getElementById('upp-chart-1'));
    chart1.draw(data, options);
};

// ..............................................................

function drawStuff2() {
    var data = new google.visualization.arrayToDataTable([
      ['Recepionist', 'YES', 'NO'],
      ['Recepionist', 50, 50],
      ['Recepionist', 50, 50],
      ['Doctor', 40, 60],
      ['Doctor', 50, 50],
      ['Doctor', 50, 50]
    ]);

    var options = {
        width: 900,
        height: 500,
        chart: {
            title: '',
            subtitle: ''
        },
        series: {
            0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
        },
        axes: {
            y: {
                distance: { label: '' }, // Left y-axis.              
            }
        }
    };

    var chart2 = new google.charts.Bar(document.getElementById('upp-chart-2'));
    chart2.draw(data, options);

};

// ..............................................................

function drawStuff3() {
    var data = new google.visualization.arrayToDataTable([
      ['Recepionist', 'YES', 'NO'],
      ['Recepionist', 70, 30],
      ['Recepionist', 70, 30],
      ['Doctor', 70, 30],
      ['Doctor', 70, 30],
      ['Doctor', 50, 50]
    ]);

    var options = {
        width: 900,
        height: 500,
        chart: {
            title: '',
            subtitle: ''
        },
        series: {
            0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
        },
        axes: {
            y: {
                distance: { label: '' }, // Left y-axis.              
            }
        }
    };


    var chart3 = new google.charts.Bar(document.getElementById('upp-chart-3'));
    chart3.draw(data, options);
};

// ..............................................................

function drawStuff4() {
    var data = new google.visualization.arrayToDataTable([
      ['Recepionist', 'YES', 'NO'],
      ['Recepionist', 70, 30],
      ['Recepionist', 70, 30],
      ['Doctor', 70, 30],
      ['Doctor', 70, 30],
      ['Doctor', 50, 50]
    ]);

    var options = {
        width: 900,
        height: 500,
        chart: {
            title: '',
            subtitle: ''
        },
        series: {
            0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
        },
        axes: {
            y: {
                distance: { label: '' }, // Left y-axis.              
            }
        }
    };


    var chart4 = new google.charts.Bar(document.getElementById('upp-chart-4'));
    chart4.draw(data, options);
};

// ..............................................................

function drawStuff5() {
    var data = new google.visualization.arrayToDataTable([
      ['Recepionist', 'YES', 'NO'],
      ['Recepionist', 70, 30],
      ['Recepionist', 70, 30],
      ['Doctor', 70, 30],
      ['Doctor', 70, 30],
      ['Doctor', 50, 50]
    ]);

    var options = {
        width: 900,
        height: 500,
        chart: {
            title: '',
            subtitle: ''
        },
        series: {
            0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
        },
        axes: {
            y: {
                distance: { label: '' }, // Left y-axis.              
            }
        }
    };


    var chart5 = new google.charts.Bar(document.getElementById('upp-chart-5'));
    chart5.draw(data, options);
};

// ..............................................................





