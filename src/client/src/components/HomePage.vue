<template>
  <div class="hello">
    <h1>please login to check btc/usd rates</h1>
    <router-link  to="/login"><button>Login</button></router-link>
    <router-link  to="/rate"><button>BTC/USD Rate</button></router-link>
  </div>
</template>

<script>
export default {
  name: 'HomePage'
}
</script>
