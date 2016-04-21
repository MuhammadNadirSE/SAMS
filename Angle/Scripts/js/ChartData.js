var columnChart = new Highcharts.Chart({
    chart: {
        type: 'column',
        renderTo: 'column',
    },
    title: {
        text: 'Client Groups Distribution'
    },
    credits: {
        enabled: false
    },
    xAxis: {
        type: 'category'
    },
    yAxis: {
        title: {
            text: 'Total Amount'
        }
    },
    legend: {
        enabled: false,
    },
    plotOptions: {
        series: {
            borderWidth: 0,
            dataLabels: {
                enabled: true,
            }
        }
    },

    //Main Series
    series: [{
        name: 'Total Bills by Client',
        colorByPoint: true,
        data: [{
            name: 'Telstra',
            y: 140415,
            drilldown: 'Telstra'
        },
        {
            name: 'Optus',
            y: 160596,
            drilldown: 'optus'
        },
        {
            name: 'Macquarie',
            y: 120413,
            drilldown: 'dist3'
        },
        {
            name: 'Spark Digital',
            y: 132493,
            drilldown: 'dist4'
        }]
    }],


    drilldown: {
        series: [
            //First DrillDown
            {
                id: 'Telstra',
                name: 'Telstra',
                data: [{
                    name: 'Client-01',
                    y: 12045,
                    drilldown: 'tlclient01'
                },
                {
                    name: 'Client-02',
                    y: 6215,
                    drilldown: 'tlclient02'
                },
                {
                    name: 'Client-03',
                    y: 8542,
                    drilldown: 'tlclient03'
                },
                {
                    name: 'Client-04',
                    y: 8542,
                    drilldown: 'tlclient04'
                },
                {
                    name: 'Client-05',
                    y: 9120,
                    drilldown: 'tlclient05'
                },
                {
                    name: 'Client-06',
                    y: 4785,
                    drilldown: 'tlclient06'
                },
                {
                    name: 'Client-07',
                    y: 10245,
                    drilldown: 'tlclient07'
                },
                {
                    name: 'Client-08',
                    y: 9314,
                    drilldown: 'tlclient08'
                },
                {
                    name: 'Client-09',
                    y: 8542,
                    drilldown: 'tlclient09'
                },
                {
                    name: 'Client-10',
                    y: 4852,
                    drilldown: 'tlclient10'
                },
                {
                    name: 'Client-11',
                    y: 9634,
                    drilldown: 'tlclient11'
                },
                {
                    name: 'Client-12',
                    y: 11201,
                    drilldown: 'tlclient12'
                },
                {
                    name: 'Client-13',
                    y: 8236,
                    drilldown: 'tlclient13'
                }
                ]
            },
            {
                id: 'optus',
                name: 'Optus',
                data: [{
                    name: 'Client-01',
                    y: 5249,
                    drilldown: 'opclient01'
                },
                {
                    name: 'Client-02',
                    y: 2486,
                    drilldown: 'opclient02'
                },
                {
                    name: 'Client-03',
                    y: 9648,
                    drilldown: 'opclient03'
                },
                {
                    name: 'Client-04',
                    y: 7126,
                    drilldown: 'opclient04'
                },
                {
                    name: 'Client-05',
                    y: 4129,
                    drilldown: 'opclient05'
                },
                {
                    name: 'Client-06',
                    y: 8215,
                    drilldown: 'opclient06'
                },
                {
                    name: 'Client-07',
                    y: 3688,
                    drilldown: 'opclient07'
                },
                {
                    name: 'Client-08',
                    y: 3944,
                    drilldown: 'opclient08'
                },
                {
                    name: 'Client-09',
                    y: 7459,
                    drilldown: 'opclient09'
                }]
            },
            {
                id: 'dist3',
                name: 'Macquarie',
                data: [{
                    name: 'Client-01',
                    y: 5249,
                    drilldown: 'd3client01'
                },
                {
                    name: 'Client-02',
                    y: 2486,
                    drilldown: 'd3client02'
                },
                {
                    name: 'Client-03',
                    y: 9648,
                    drilldown: 'd3client03'
                },
                {
                    name: 'Client-04',
                    y: 7126,
                    drilldown: 'd3client04'
                },
                {
                    name: 'Client-05',
                    y: 4129,
                    drilldown: 'd3client05'
                },
                {
                    name: 'Client-06',
                    y: 8215,
                    drilldown: 'd3client06'
                },
                {
                    name: 'Client-07',
                    y: 3688,
                    drilldown: 'd3client07'
                }]
            },
            {
                id: 'dist4',
                name: 'Distributor 04',
                data: [{
                    name: 'Client-01',
                    y: 8516,
                    drilldown: 'd4client01'
                },
                {
                    name: 'Client-02',
                    y: 7153,
                    drilldown: 'd4client02'
                },
                {
                    name: 'Client-03',
                    y: 8526,
                    drilldown: 'd4client03'
                },
                {
                    name: 'Client-04',
                    y: 9345,
                    drilldown: 'd4client04'
                },
                {
                    name: 'Client-05',
                    y: 6314,
                    drilldown: 'd4client05'
                }]
            },

            //Second Drill Down
            {
                id: 'tlclient01',
                name: 'Telstra Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient02',
                name: 'Telstra Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient03',
                name: 'Telstra Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient04',
                name: 'Telstra Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient05',
                name: 'Telstra Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient06',
                name: 'Telstra Client 06',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient07',
                name: 'Telstra Client 07',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient08',
                name: 'Telstra Client 08',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient09',
                name: 'Telstra Client 09',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient10',
                name: 'Telstra Client 10',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient11',
                name: 'Telstra Client 11',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient12',
                name: 'Telstra Client 12',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient13',
                name: 'Telstra Client 13',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient01',
                name: 'Optus Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient02',
                name: 'Optus Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient03',
                name: 'Optus Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient04',
                name: 'Optus Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient05',
                name: 'Optus Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient06',
                name: 'Optus Client 06',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient07',
                name: 'Optus Client 07',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient08',
                name: 'Optus Client 08',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient09',
                name: 'Optus Client 09',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client01',
                name: 'Macquarie Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client02',
                name: 'Macquarie Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client03',
                name: 'Macquarie Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client04',
                name: 'Macquarie Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client05',
                name: 'Macquarie Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client06',
                name: 'Macquarie Client 06',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client07',
                name: 'Macquarie Client 07',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client01',
                name: 'Spark Digital Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client02',
                name: 'Spark Digital Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client03',
                name: 'Spark Digital Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client04',
                name: 'Spark Digital Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client05',
                name: 'Spark Digital Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            }]
    }
});

var pieChart = new Highcharts.Chart({
    chart: {
        type: 'pie',
        renderTo: 'pie',
    },
    title: {
        text: 'Client Groups Distribution'
    },
    credits: {
        enabled: false
    },
    xAxis: {
        type: 'category'
    },
    yAxis: {
        title: {
            text: 'Total Amount'
        }
    },
    legend: {
        enabled: false,
    },
    plotOptions: {
        series: {
            borderWidth: 0,
            dataLabels: {
                enabled: true,
            }
        }
    },

    //Main Series
    series: [{
        name: 'Total Bills by Client',
        colorByPoint: true,
        data: [{
            name: 'Telstra',
            y: 140415,
            drilldown: 'Telstra'
        },
        {
            name: 'Optus',
            y: 160596,
            drilldown: 'optus'
        },
        {
            name: 'Macquarie',
            y: 120413,
            drilldown: 'dist3'
        },
        {
            name: 'Spark Digital',
            y: 132493,
            drilldown: 'dist4'
        }]
    }],


    drilldown: {
        series: [
            //First DrillDown
            {
                id: 'Telstra',
                name: 'Telstra',
                data: [{
                    name: 'Client-01',
                    y: 12045,
                    drilldown: 'tlclient01'
                },
                {
                    name: 'Client-02',
                    y: 6215,
                    drilldown: 'tlclient02'
                },
                {
                    name: 'Client-03',
                    y: 8542,
                    drilldown: 'tlclient03'
                },
                {
                    name: 'Client-04',
                    y: 8542,
                    drilldown: 'tlclient04'
                },
                {
                    name: 'Client-05',
                    y: 9120,
                    drilldown: 'tlclient05'
                },
                {
                    name: 'Client-06',
                    y: 4785,
                    drilldown: 'tlclient06'
                },
                {
                    name: 'Client-07',
                    y: 10245,
                    drilldown: 'tlclient07'
                },
                {
                    name: 'Client-08',
                    y: 9314,
                    drilldown: 'tlclient08'
                },
                {
                    name: 'Client-09',
                    y: 8542,
                    drilldown: 'tlclient09'
                },
                {
                    name: 'Client-10',
                    y: 4852,
                    drilldown: 'tlclient10'
                },
                {
                    name: 'Client-11',
                    y: 9634,
                    drilldown: 'tlclient11'
                },
                {
                    name: 'Client-12',
                    y: 11201,
                    drilldown: 'tlclient12'
                },
                {
                    name: 'Client-13',
                    y: 8236,
                    drilldown: 'tlclient13'
                }
                ]
            },
            {
                id: 'optus',
                name: 'Optus',
                data: [{
                    name: 'Client-01',
                    y: 5249,
                    drilldown: 'opclient01'
                },
                {
                    name: 'Client-02',
                    y: 2486,
                    drilldown: 'opclient02'
                },
                {
                    name: 'Client-03',
                    y: 9648,
                    drilldown: 'opclient03'
                },
                {
                    name: 'Client-04',
                    y: 7126,
                    drilldown: 'opclient04'
                },
                {
                    name: 'Client-05',
                    y: 4129,
                    drilldown: 'opclient05'
                },
                {
                    name: 'Client-06',
                    y: 8215,
                    drilldown: 'opclient06'
                },
                {
                    name: 'Client-07',
                    y: 3688,
                    drilldown: 'opclient07'
                },
                {
                    name: 'Client-08',
                    y: 3944,
                    drilldown: 'opclient08'
                },
                {
                    name: 'Client-09',
                    y: 7459,
                    drilldown: 'opclient09'
                }]
            },
            {
                id: 'dist3',
                name: 'Distributor 03',
                data: [{
                    name: 'Client-01',
                    y: 5249,
                    drilldown: 'd3client01'
                },
                {
                    name: 'Client-02',
                    y: 2486,
                    drilldown: 'd3client02'
                },
                {
                    name: 'Client-03',
                    y: 9648,
                    drilldown: 'd3client03'
                },
                {
                    name: 'Client-04',
                    y: 7126,
                    drilldown: 'd3client04'
                },
                {
                    name: 'Client-05',
                    y: 4129,
                    drilldown: 'd3client05'
                },
                {
                    name: 'Client-06',
                    y: 8215,
                    drilldown: 'd3client06'
                },
                {
                    name: 'Client-07',
                    y: 3688,
                    drilldown: 'd3client07'
                }]
            },
            {
                id: 'dist4',
                name: 'Distributor 04',
                data: [{
                    name: 'Client-01',
                    y: 8516,
                    drilldown: 'd4client01'
                },
                {
                    name: 'Client-02',
                    y: 7153,
                    drilldown: 'd4client02'
                },
                {
                    name: 'Client-03',
                    y: 8526,
                    drilldown: 'd4client03'
                },
                {
                    name: 'Client-04',
                    y: 9345,
                    drilldown: 'd4client04'
                },
                {
                    name: 'Client-05',
                    y: 6314,
                    drilldown: 'd4client05'
                }]
            },

            //Second Drill Down
            {
                id: 'tlclient01',
                name: 'Telstra Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient02',
                name: 'Telstra Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient03',
                name: 'Telstra Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient04',
                name: 'Telstra Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient05',
                name: 'Telstra Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient06',
                name: 'Telstra Client 06',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient07',
                name: 'Telstra Client 07',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient08',
                name: 'Telstra Client 08',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient09',
                name: 'Telstra Client 09',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient10',
                name: 'Telstra Client 10',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient11',
                name: 'Telstra Client 11',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient12',
                name: 'Telstra Client 12',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'tlclient13',
                name: 'Telstra Client 13',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient01',
                name: 'Optus Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient02',
                name: 'Optus Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient03',
                name: 'Optus Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient04',
                name: 'Optus Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient05',
                name: 'Optus Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient06',
                name: 'Optus Client 06',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient07',
                name: 'Optus Client 07',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient08',
                name: 'Optus Client 08',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'opclient09',
                name: 'Optus Client 09',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client01',
                name: 'Macquarie Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client02',
                name: 'Macquarie Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client03',
                name: 'Macquarie Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client04',
                name: 'Macquarie Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client05',
                name: 'Macquarie Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client06',
                name: 'Macquarie Client 06',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd3client07',
                name: 'Macquarie Client 07',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client01',
                name: 'Spark Digital Client 01',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client02',
                name: 'Spark Digital Client 02',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client03',
                name: 'Spark Digital Client 03',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client04',
                name: 'Spark Digital Client 04',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            },
            {
                id: 'd4client05',
                name: 'Spark Digital Client 05',
                data: [
                {
                    name: 'Landline',
                    y: 1458,
                },
                {
                    name: 'Mobile - Local',
                    y: 4136,
                },
                {
                    name: 'Mobile - Intl',
                    y: 2569,
                },
                {
                    name: 'Data Usage',
                    y: 3596,
                }]
            }]
    }
});

var twelveMonthsCat = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Sep', 'Oct', 'Nov', 'Dec'];
var twelveMonths = [
    {
        name: 'Telstra',
        data: [240415, 260596, 220413, 232493, 220413, 232493, 260596, 220413, 232493, 220413, 232493, 260596]
    }, {
        name: 'Macquarie    ',
        data: [192699, 184589, 207856, 186987, 195269, 208965, 192699, 184589, 184589, 207856, 208965, 192699]
    }, {
        name: 'Optus',
        data: [225036, 245896, 248625, 285167, 275369, 248963, 245896, 224862, 225036, 245896, 285167, 275369]
    }, {
        name: 'Spark Digital',
        data: [184785, 192459, 174257, 205369, 175634, 165236, 184785, 192459, 192459, 174257, 175634, 165236]
    }
];

var sixMonthsCat = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'];
var sixMonths = [
    {
        name: 'Telstra',
        data: [240415, 260596, 220413, 232493, 220413, 232493]
    }, {
        name: 'Macquarie    ',
        data: [192699, 184589, 207856, 186987, 195269, 208965]
    }, {
        name: 'Optus',
        data: [225036, 245896, 248625, 285167, 275369, 248963]
    }, {
        name: 'Spark Digital',
        data: [184785, 192459, 174257, 205369, 175634, 165236]
    }
];

var threeMonthsCat = ['Apr', 'May', 'Jun'];
var threeMonths = [
    {
        name: 'Telstra',
        data: [232493, 220413, 232493]
    }, {
        name: 'Macquarie    ',
        data: [186987, 195269, 208965]
    }, {
        name: 'Optus',
        data: [285167, 275369, 248963]
    }, {
        name: 'Spark Digital',
        data: [205369, 175634, 165236]
    }
];

var lineChart = new Highcharts.Chart({
    chart: {
        type: 'line',
        renderTo: 'line',
    },
    title: {
        text: 'Monthly Average Bill  - Last Three Months',
        x: -20 //center
    },
    //subtitle: {
    //    text: 'Source: WorldClimate.com',
    //    x: -20
    //},
    xAxis: {
        categories: threeMonthsCat
    },
    yAxis: {
        title: {
            text: 'Total Amount'
        },
        plotLines: [{
            value: 0,
            width: 1,
            color: '#808080'
        }]
    },
    credits: {
        enabled: false
    },
    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle',
        borderWidth: 0
    },
    series: threeMonths
});

$('#threeMonths').click(function () {

    var lineChart = new Highcharts.Chart({
        chart: {
            type: 'line',
            renderTo: 'line',
        },
        title: {
            text: 'Monthly Average Bill - Last Three Months',
            x: -20 //center
        },
        //subtitle: {
        //    text: 'Source: WorldClimate.com',
        //    x: -20
        //},
        xAxis: {
            categories: threeMonthsCat
        },
        yAxis: {
            title: {
                text: 'Total Amount'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        credits: {
            enabled: false
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: threeMonths
    });
    
});

$('#sixMonths').click(function () {

    var lineChart = new Highcharts.Chart({
        chart: {
            type: 'line',
            renderTo: 'line',
        },
        title: {
            text: 'Monthly Average Bill - Last Six Months',
            x: -20 //center
        },
        //subtitle: {
        //    text: 'Source: WorldClimate.com',
        //    x: -20
        //},
        xAxis: {
            categories: sixMonthsCat
        },
        yAxis: {
            title: {
                text: 'Total Amount'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        credits: {
            enabled: false
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: sixMonths
    });

});

$('#twelveMonths').click(function () {

    var lineChart = new Highcharts.Chart({
        chart: {
            type: 'line',
            renderTo: 'line',
        },
        title: {
            text: 'Monthly Average Bill - Last Twelve Months',
            x: -20 //center
        },
        //subtitle: {
        //    text: 'Source: WorldClimate.com',
        //    x: -20
        //},
        xAxis: {
            categories: twelveMonthsCat
        },
        yAxis: {
            title: {
                text: 'Total Amount'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        credits: {
            enabled: false
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: twelveMonths
    });

});
