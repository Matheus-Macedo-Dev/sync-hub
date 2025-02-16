<template>
    <v-container>
      <v-row class="mb-2">
        <v-col cols="12" md="4">
          <v-text-field
            v-model="filterByNumber"
            label="Card Number"
            variant="outlined"
            clearable
          ></v-text-field>
        </v-col>
        <v-col cols="12" md="4">
          <v-select
            v-model="filterBySuit"
            :items="['HEARTS', 'SPADES', 'DIAMONDS', 'CLUBS']"
            label="Suit Filter"
            variant="outlined"
            clearable
          ></v-select>
        </v-col>
        <v-col cols="12" md="4" class="d-flex align-center">
          <v-btn @click="fetchFilteredData" color="primary" :loading="loading">Search</v-btn>
        </v-col>
      </v-row>
    </v-container>
    <v-container>
      <v-data-table :headers="headers" :items="items" class="elevation-1">
        <template v-slot:item.image="{ item }">
          <v-avatar size="150">
            <v-img :src="item.image" alt="Avatar" />
          </v-avatar>
        </template>
      </v-data-table>
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { ref, onMounted } from "vue";
  import api from "../configuration/axiosConfig.ts";
  
  const headers = [
    { title: "Image", key: "image" },
    { title: "Name", key: "value" },
    { title: "Description", key: "suit" }
  ];
  
  const items = ref([]); 
  const filterByNumber = ref("");
  const filterBySuit = ref(""); 
  const loading = ref(false); 

 
  const fetchData = async () => {
    loading.value = true;
    try {
      const response = await api.get("Home");
  
      items.value = response.data;
    } catch (error) {
      console.error("Error while fetching data:", error);
    } finally {
      loading.value = false;
    }
  };

  const fetchFilteredData = async () => {
    loading.value = true;
    try {
      const response = await api.get("Home/filtered", {
        params: {
          value: filterByNumber.value || null,
          suit: filterBySuit.value || null
        }
      });
  
      items.value = response.data;
    } catch (error) {
      console.error("Error while fetching data:", error);
    } finally {
      loading.value = false;
    }
  };
  
  onMounted(fetchData);
  </script>
  