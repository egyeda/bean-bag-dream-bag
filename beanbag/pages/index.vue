<template>
  <div>
    <h1>Products</h1>
    <v-file-input
      accept="image/*"
      label="Product picture"
      prepend-icon="mdi-camera"
      @change="handleFileChange"
      v-model="file"
    ></v-file-input>
    <div v-for="product in products" :key="product.id">
      <p> {{ product.name }} </p>
    </div>

    <div class="my-5">
      <v-text-field
        v-model="productName"
        label="Product Name"
        outlined
      />

      <v-btn
        color="primary"
        class="mt-5"
        @click="saveProduct"
      >
        Save
      </v-btn>
    </div>
  </div>
</template>

<script>
import { mapState, mapActions, mapMutations } from 'vuex'

export default {
  name: 'IndexPage',
  computed:{
    ...mapState('products', ['products']),
  },
  data: () => ({
    productName: '',
    file: undefined,
  }),
  methods: {
    ...mapMutations(['reset']),
    ...mapMutations({
      resetProducts: 'products/reset',
    }),
    ...mapActions('products', ['createProduct']),
    saveProduct() {
      this.createProduct({ product: { name: this.productName }})
      this.productName = ''
    },
    async handleFileChange(file) {
      if(!file){
        return
      }

      const form = new FormData()
      form.append('image', file)

      const result = await this.$axios.$post('http://localhost:5000/api/images', form)
      console.log(result)
      // const files = e.target.files
      // const formData = new FormData()
      // for (let i = 0; i < files.length; i++) {
      //   const file = files[i]
      //   formData.append('files', file, file.name)
      // }
      // const response = await this.$axios.$post('/upload', formData)
      // console.log(response)
    },
  },
}
</script>
