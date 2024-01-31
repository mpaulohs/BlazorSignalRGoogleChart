


window.drawChart = (toppingsJson) => {    
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(() => drawChart(toppingsJson));

    function drawChart(toppingsJson) {
        var toppings = JSON.parse(toppingsJson);
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Topping');
        data.addColumn('number', 'Slices');

        var rows = toppings.map(topping => [topping.Topping, topping.Slices]);
        data.addRows(rows);

        var options = {
            'title': 'How Much Pizza I Ate Last Night'            
        };
        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
        chart.draw(data, options);
    }
}




//window.drawChart = () => {    
//    google.charts.load('current', { 'packages': ['corechart'] });
//    google.charts.setOnLoadCallback(drawChart);

//    function drawChart(toppings) {
//        var data = new google.visualization.DataTable();
//        data.addColumn('string', 'Topping');
//        data.addColumn('number', 'Slices');
//        data.addRows([
//            ['Mushrooms', 3],
//            ['Onions', 1],
//            ['Olives', 1],
//            ['Zucchini', 1],
//            ['Pepperoni', 2]
//        ]);

//        var options = {
//            'title': 'How Much Pizza I Ate Last Night',
//            'width': 400,
//            'height': 300
//        };

//        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));
//        chart.draw(data, options);
//    }
//}

