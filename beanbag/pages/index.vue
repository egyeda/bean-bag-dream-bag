<template>
  <div style="height: 1500px">
    <h1>{{ $t('products') }}</h1>

    <div v-for="product in products" :key="product.id">
      <div>
        {{ product.name }}
        <div>
          <img :src="`http://localhost:5000/api/images/${product.image}`" alt="product image" width="400">
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {mapState} from 'vuex'

export default {
  name: 'IndexPage',
  computed: {
    ...mapState('products', ['products']),
  },
}
</script>

<style scoped>

</style>
