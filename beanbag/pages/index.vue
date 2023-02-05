<template>
  <div>
    <h1>Products</h1>

    <div v-for="product in products" :key="product.id">
      <div>
        {{ product.name }}
        <div>
          <img :src="`http://localhost:5000/api/images/${product.image}`" alt="product image" width="400">
        </div>
      </div>
    </div>

    <div class="my-5">
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

              <v-btn color="primary" class="mt-5" @click="saveProduct">
                Save
              </v-btn>
            </div>
          </v-stepper-content>

          <v-stepper-content step="3">
            <div>
              Succcess!
            </div>
          </v-stepper-content>
        </v-stepper-items>
      </v-stepper>
    </div>
  </div>
</template>

<script>
import {mapState, mapActions, mapMutations} from 'vuex'

export default {
  name: 'IndexPage',
  computed: {
    ...mapState('products', ['products']),
    ...mapState('images', ['uploadPromise']),
  },
  data: () => ({
    productName: '',
    file: undefined,
    step: 1,
  }),
  methods: {
    ...mapMutations('images', { resetImages: 'reset'}),
    ...mapActions('products', ['createProduct']),
    ...mapActions('images', ['startImageUpload']),
    async handleFileChange(file) {
      if (!file) {
        return
      }

      const form = new FormData()
      form.append('image', file)

      this.startImageUpload({form})
      this.step++
    },
    async saveProduct() {
      if(this.uploadPromise === null){
        console.log("No image uploaded")
        return
      }
      const image = await this.uploadPromise
      await this.createProduct({product: {name: this.productName, image}})
      this.productName = ''
      this.step++
      this.resetImages()
    },
  },
}
</script>
