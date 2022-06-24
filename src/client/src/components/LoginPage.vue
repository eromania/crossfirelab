<template>
  <div class="login">
    <div class="alert alert-info">
      Username: cfl<br />
      Password: 123
    </div>
    <h2>Login</h2>
    <form @submit.prevent="login">
      <input v-model="username" placeholder="username" />
      <br />
      <br />
      <input v-model="password" placeholder="password" type="password" />
      <br />
      <br />
      <button :disabled="!(username && password)" type="submit">Login</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "LoginPage",
  data: () => {
    return {
      username: "",
      password: "",
    };
  },
  methods: {
    async login(e) {
      e.preventDefault();
       let self = this;
      axios.defaults.headers.common["Accept"] = "application/json";

      axios({
        method: "post",
        url: "https://localhost:7216/authenticate",
        data: {
          username: this.username,
          password: this.password,
        },
      })
        .then(function (response) {
          console.log(response);
          localStorage.setItem('token', JSON.stringify(response.data.token));
          self.$router.push("/rate")
        })
        .catch(function (error) {
          console.log(error);
        });
    },
  },
};
</script>
