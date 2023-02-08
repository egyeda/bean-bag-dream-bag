const initState = () => ({
  uploadPromise: null,
  active: false,
  step: 1,
})

export const state = initState

export const mutations = {
  setTask(state, {task}) {
    state.uploadPromise = task
    state.step++
  },
  increaseStep(state) {
    state.step++
  },
  toggleActivity(state) {
    state.active = !state.active
    if(!state.active) {
      Object.assign(state, initState())
    }
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  startImageUpload({ commit, dispatch }, {form}) {
    const task = this.$axios.$post('/api/images', form)
    commit('setTask', {task})
  },
  async createProduct({ commit, dispatch }, {product}) {
    await this.$axios.$post('/api/products', product)
    dispatch("fetchProducts")
  }
}
