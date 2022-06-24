<template>
  <div class="login">
    <h2>BTC/USD Rate</h2>
    <line-chart v-if="loaded" :chart-data="chartData" :width="400"></line-chart>
  </div>
</template>

<script>
import axios from "axios";
import LineChart from '../helper/line-chart.js';

export default {
  name: "RatePage",
  components: {
    LineChart
  },
  data: () => ({
    loaded: false,
    chartData: '',
  }),
  mounted() {
    this.loaded = false;

    try {
      const instance = axios.create({
        baseURL: "https://localhost:7216",
        headers: {
          Authorization: "Bearer " + localStorage.getItem('token'),
          Accept: "application/json"
        },
      });

      instance.get("/ExchangeRate?days=1").then((response) => {
        this.chartData = {
          labels: response.data.map(item => item.time),
          datasets: [{
            label: 'BTC/USD',
            data: response.data.map(item => item.rate),
            borderColor: "#3e95cd",
            fill: false
          }
          ]
        }
        this.loaded = true;
      }).catch(function (error) {
        console.log(error);
      });
    } catch (e) {
      console.error(e);
    }
  },
};
</script>
