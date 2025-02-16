<template>
    <v-app-bar color="primary" dark>
      <v-toolbar-title>{{ title }}</v-toolbar-title>
    </v-app-bar>
  </template>
  
  <script setup>
  defineProps({
    title: {
      type: String,
      required: true
    }
  });
  </script>
  