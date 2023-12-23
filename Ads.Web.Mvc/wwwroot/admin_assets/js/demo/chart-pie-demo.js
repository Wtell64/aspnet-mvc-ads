// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';

// Pie Chart Example
var categoryLabels = [];
var advertCounts = [];

$.ajax({
  url: 'Admin/Home/PopularCategoriesPie',
  type: 'GET',
  dataType: 'json',
  success: function (data) {
    
    for (var i = 0; i < data.dto.length; i++)
    {
      categoryLabels.push(data.dto[i].categoryLabel);
      advertCounts.push(data.dto[i].advertCount);
    }
    //console.log(data.dto);
   
    var ctx = document.getElementById("myPieChart");
    var myPieChart = new Chart(ctx, {
      type: 'doughnut',
      data: {
        labels: categoryLabels,
        datasets: [{
          data: advertCounts,
          backgroundColor: ['#4e73df', '#1cc88a', '#36b9cc','#f3e600', '#ff4444'],
          hoverBackgroundColor: ['#2e59d9', '#17a673', '#2c9faf', '#c3b200', '#b30000'],

          hoverBorderColor: "rgba(234, 236, 244, 1)",
        }],
      },
      options: {
        maintainAspectRatio: false,
        tooltips: {
          backgroundColor: "rgb(255,255,255)",
          bodyFontColor: "#858796",
          borderColor: '#dddfeb',
          borderWidth: 1,
          xPadding: 15,
          yPadding: 15,
          displayColors: false,
          caretPadding: 10,
        },
        legend: {
          display: false
        },
        cutoutPercentage: 80,
      },
    });
  },
  error: function (error) {
    console.error('Error fetching data:', error);
  }
});


