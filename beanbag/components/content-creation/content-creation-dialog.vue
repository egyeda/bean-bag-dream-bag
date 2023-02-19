<template>
    <v-dialog persistent :value="active" @change="toggleActivity">
      <template v-slot:activator="{ on }">
        <v-btn depressed v-on="on" @click="toggleActivity">
          Upload
        </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Upload</span>
        </v-card-title>
  
        <v-card-text>
          
        </v-card-text>
  
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="toggleActivity">
            Cancel
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>
  
  <script>
  import {mapState, mapActions, mapMutations} from "vuex";
  
  export default {
    name: "content-creation-dialog",
    computed: {
      ...mapState('image-upload', ['uploadPromise', 'active', 'step']),
    },
    methods: {
      ...mapMutations('image-upload', ['reset', 'toggleActivity', 'increaseStep']),
      ...mapActions('image-upload', ['startImageUpload']),
      ...mapActions('products', ['createProduct']),
    },
  }
  </script>
  
  <style scoped>
  
  </style>
  