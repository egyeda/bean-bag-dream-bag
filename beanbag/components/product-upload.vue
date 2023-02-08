<template>

  <v-dialog persistent :value="active" @change="toggleActivity">
    <v-card>
      <v-card-title>
        <span class="headline">Upload</span>
      </v-card-title>

      <v-card-text>
        <v-stepper v-model="step">
          <v-stepper-header>
            <v-stepper-step :complete="step > 1" step="1">
              {{ $t('picture_upload') }}
            </v-stepper-step>

            <v-divider></v-divider>

            <v-stepper-step :complete="step > 2" step="2">
              {{ $t('product_information') }}
            </v-stepper-step>

            <v-divider></v-divider>

            <v-stepper-step step="3">
              {{ $t('product_preview') }}
            </v-stepper-step>
          </v-stepper-header>

          <v-stepper-items>
            <v-stepper-content step="1">
              <div>
                <v-file-input accept="image/*" label="Product picture" prepend-icon="mdi-camera" @change="handleFileChange"
                              v-model="file"></v-file-input>
              </div>
            </v-stepper-content>

            <v-stepper-content step="2">

              <div>
                <v-text-field v-model="productName" label="Product Name" outlined/>
                <v-btn color="primary" class="mt-5" @click="prepareForProductReviewAndProceed">
                  Next
                </v-btn>
              </div>
            </v-stepper-content>

            <v-stepper-content step="3">
              <div v-if="productImageName">
                <v-img contain height="300" :src="`http://localhost:5000/api/images/${productImageName}`" aspect-ratio="1.7"></v-img>
                Product name: {{ productName }}
              </div>

              <v-btn color="primary" class="mt-5" @click="saveProduct">
                Save
              </v-btn>
            </v-stepper-content>
          </v-stepper-items>
        </v-stepper>
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
  name: "product-upload",
  computed: {
    ...mapState('images', ['uploadPromise', 'active', 'step']),
  },
  data: () => ({
    productName: '',
    productImage: undefined,
    productImageName: '',
    file: undefined,
  }),
  methods: {
    ...mapMutations('images', ['reset', 'toggleActivity', 'increaseStep']),
    ...mapActions('images', ['startImageUpload', 'createProduct']),
    async handleFileChange(file) {
      if (!file) {
        return
      }

      const form = new FormData()
      form.append('image', file)

      this.startImageUpload({form})
    },
    async prepareForProductReviewAndProceed(){
      if(this.uploadPromise === null){
        console.log("No image uploaded")
        return
      }
      this.productImageName = await this.uploadPromise
      this.productImage = await this.$axios.$get(`/api/images/${this.productImageName}`)
      this.increaseStep()
    },
    async saveProduct() {
      await this.createProduct({product: {name: this.productName, image: this.productImageName}})
      this.productName = ''
      this.reset()
    },
  },
}
</script>

<style scoped>

</style>
