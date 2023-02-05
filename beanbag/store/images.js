const initState = () => ({
  uploadPromise: null,
})

export const state = initState

export const mutations = {
  setTask(state, {task}) {
    state.uploadPromise = task
  },
  reset(state) {
    Object.assign(state, initState())
  }
}

export const actions = {
  startImageUpload({ commit, dispatch }, {form}) {
    const task = this.$axios.$post('http://localhost:5000/api/images', form)
    commit('setTask', {task})
  }
}
