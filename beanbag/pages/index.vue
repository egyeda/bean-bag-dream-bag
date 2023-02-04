<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
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
      episode 3
      <v-btn
        color="primary"
        class="mt-5"
        @click="resetProducts"
      > Reset </v-btn>
    </v-col>
  </v-row>
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
  },
}
</script>
