<template>
  <v-app>
    <v-app-bar
        app
        dense
      >
        <v-toolbar-title>Dreambags</v-toolbar-title>

        <v-spacer></v-spacer>

        <nuxt-link
          :key="'gb'"
          class="country-flag"
          :to="switchLocalePath('en')">
          <country-flag country='gb'
               size="normal"
               :rounded="true"/></nuxt-link>
        <nuxt-link
          :key="'hu'"
          class="country-flag"
          :to="switchLocalePath('hu')">
          <country-flag country='hu'
               size="normal"
               :rounded="true"/></nuxt-link>
        <nuxt-link
          :key="'ro'"
          class="country-flag"
          :to="switchLocalePath('ro')">
          <country-flag country='ro'
               :rounded="true"
               size="normal"/></nuxt-link>
        <product-upload></product-upload>
      </v-app-bar>
    <v-main >
      <Nuxt />
    </v-main>
  </v-app>
</template>

<script>

import {mapMutations} from "vuex";
import ProductUpload from "../components/product-upload.vue";

export default {
  name: 'DefaultLayout',
  components: {
    ProductUpload,
  },
  methods:{
    ...mapMutations('image-upload', ['toggleActivity']),
  }
}
</script>

<style lang="scss" scoped>
.country-flag {
  margin: 0 0.5rem;
}
</style>
