<template>
    <HeaderComponent title="Available Cards" />
      <v-container>
        <DataGrid />
      </v-container>
</template>
    
<script setup>
import HeaderComponent from "@/components/Header.vue";
import DataGrid from "@/components/DataGrid.vue";
</script>