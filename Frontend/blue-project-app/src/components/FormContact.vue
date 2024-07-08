<template>
  <div class="contact-list">
    <h2>Lista de Contatos</h2>
    <PvButton label="Novo Contato" icon="pi pi-plus" @click="openNew" class="button-new" />

    <PvDataTable :value="contacts" paginator rows="10" responsiveLayout="scroll">
      <PvColumn field="name" header="Nome"></PvColumn>
      <PvColumn field="email" header="E-mail"></PvColumn>
      <PvColumn field="phone" header="Telefone"></PvColumn>
      <PvColumn header="Ações">
        <template #body="slotProps">
          <PvButton icon="pi pi-pencil" @click="editContact(slotProps.data)" class="button-edit" />
          <PvButton icon="pi pi-trash" class="p-button-danger button-delete" @click="deleteContact(slotProps.data.id)" />
        </template>
      </PvColumn>
    </PvDataTable>

    <PvDialog :visible="contactDialog" modal header="Detalhes do Contato" @hide="contactDialog = false" class="dialog" :closable="false">
      <div class="p-field p-grid">
        <label for="name" class="p-col-fixed label">Nome</label>
        <PvInputText id="name" v-model="contact.name" class="p-inputtext p-component input" />
      </div>
      <div class="p-field p-grid">
        <label for="email" class="p-col-fixed label">E-mail</label>
        <PvInputText id="email" v-model="contact.email" class="p-inputtext p-component input" />
      </div>
      <div class="p-field p-grid">
        <label for="phone" class="p-col-fixed label">Telefone</label>
        <PvInputText id="phone" v-model="contact.phone" class="p-inputtext p-component input" />
      </div>
      <PvButton label="Salvar" icon="pi pi-check" @click="saveContact" class="button-save" />
      <PvButton label="Cancelar" icon="pi pi-times" @click="cancelContact" class="button-cancel" />
    </PvDialog>

    <PvToast ref="toast" />
  </div>
</template>

<script>
import axios from '../axios';

export default {
  data() {
    return {
      contacts: [],
      contact: { id: null, name: '', email: '', phone: '' },
      contactDialog: false
    };
  },
  methods: {
    async fetchContacts() {
      try {
        const response = await axios.get();
        this.contacts = response.data.data;
      } catch (error) {
        this.$refs.toast.add({ severity: 'error', summary: 'Erro', detail: 'Erro ao buscar contatos' });
      }
    },
    openNew() {
      this.contact = { id: null, name: '', email: '', phone: '' };
      this.contactDialog = true;
    },
    editContact(contact) {
      this.contact = { ...contact };
      this.contactDialog = true;
    },
    async saveContact() {
      if (this.contact.id) {
        try {
          const response = await axios.put(`${this.contact.id}`, this.contact);
          const index = this.contacts.findIndex(c => c.id === this.contact.id);
          this.contacts[index] = response.data.data;
          this.$refs.toast.add({ severity: 'success', summary: 'Sucesso', detail: 'Contato atualizado' });
        } catch (error) {
          this.$refs.toast.add({ severity: 'error', summary: 'Erro', detail: 'Erro ao atualizar contato' });
        }
      } else {
        try {
          const response = await axios.post('', this.contact);
          this.contacts.push(response.data.data);
          this.$refs.toast.add({ severity: 'success', summary: 'Sucesso', detail: 'Contato criado' });
        } catch (error) {
          this.$refs.toast.add({ severity: 'error', summary: 'Erro', detail: 'Erro ao criar contato' });
        }
      }
      this.contactDialog = false;
      this.contact = { id: null, name: '', email: '', phone: '' };
    },
    async deleteContact(id) {
      try {
        await axios.delete(`${id}`);
        this.contacts = this.contacts.filter(c => c.id !== id);
        this.$refs.toast.add({ severity: 'success', summary: 'Sucesso', detail: 'Contato excluído' });
      } catch (error) {
        this.$refs.toast.add({ severity: 'error', summary: 'Erro', detail: 'Erro ao excluir contato' });
      }
    },
    cancelContact() {
      this.contactDialog = false;
      this.contact = { id: null, name: '', email: '', phone: '' };
    }
  },
  mounted() {
    this.fetchContacts();
  }
};
</script>

<style scoped>
.contact-list {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}

.button-new {
  margin-bottom: 20px;
}

.button-edit, .button-delete {
  margin-right: 5px;
}

.dialog {
  width: 400px;
}

.p-field {
  margin-bottom: 15px;
}

.p-field .label {
  flex: 0 0 100px;
  display: flex;
  align-items: center;
}

.p-field .input {
  flex: 1;
}

.button-save {
  margin-top: 20px;
  display: block;
  width: 100%;
}

.button-cancel {
  margin-top: 10px;
  display: block;
  width: 100%;
  background-color: #f44336;
  color: white;
}
</style>
