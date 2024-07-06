<template>
  <div id="app">
    <FormContact />
  </div>
</template>

<script>
import FormContact from './components/FormContact.vue';

export default {
  name: 'App',
  components: {
    FormContact
  }
};
</script>

<style>
#app {
  font-family: Arial, Helvetica, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
