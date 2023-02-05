<template>
  <v-app dark>
    <nuxt-link
      :key="'en'"
      :to="switchLocalePath('en')">English</nuxt-link>
    <nuxt-link
      :key="'ro'"
      :to="switchLocalePath('ro')">Română</nuxt-link>
    <nuxt-link
      :key="'hu'"
      :to="switchLocalePath('hu')">Magyar</nuxt-link>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  computed: {
  }
}
</script>
