<template>
  <div class="d-flex justify-center">
    <div v-if="product">
      Product with id: {{ $route.params.product}}

      Product name: {{ product.name }}
      <v-img height="400" contain :src="`http://localhost:5000/api/images/${product.image}`"></v-img>
    </div>
  </div>
</template>

<script>
import {mapActions, mapState} from "vuex";

export default {

  computed:{
    ...mapState('products', ['product']),
  },
  methods:{
    ...mapActions('products', ['fetchProducts'])
  },
  async fetch(){
    const productId = this.$route.params.product
    await this.$store.dispatch('products/fetchProduct', {productId: productId})
  }
}
</script>

<style scoped>

</style>
