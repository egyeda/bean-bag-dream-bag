<template>
  <div class="app-container">
    <h1>{{ $t('products') }}</h1>

    <v-row >
      <div class="col-12 col-sm-6 col-md-4 col-lg-3 product" v-for="product in products" :key="product.id">

        <div @click="$router.push(`products/${product.id}`)">
          <div class="d-flex justify-center" >
            <img :src="`http://localhost:5000/api/images/${product.image}`" alt="product image" width="200" height="200">
          </div>
          <p>{{ product.name }}</p>
        </div>
      </div>
    </v-row>
  </div>
</template>

<script>
import {mapState} from 'vuex'

export default {
  name: 'IndexPage',
  computed: {
    ...mapState('products', ['products']),
  },
  async fetch(){
    await this.$store.dispatch('products/fetchProducts')
  }
}
</script>

<style scoped>
.product{
  width: 100%;
  display: inline-block;
  cursor: pointer;
  text-align: center;
}

</style>
