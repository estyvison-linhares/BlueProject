import 'primeicons/primeicons.css';
import PrimeVue from 'primevue/config';
import 'primevue/resources/primevue.min.css';
import 'primevue/resources/themes/saga-blue/theme.css';
import { createApp } from 'vue';
import App from './App.vue';

import PvButton from 'primevue/button';
import PvColumn from 'primevue/column';
import PvDataTable from 'primevue/datatable';
import PvDialog from 'primevue/dialog';
import PvInputText from 'primevue/inputtext';
import PvToast from 'primevue/toast';
import ToastService from 'primevue/toastservice';

const app = createApp(App);

app.use(PrimeVue);
app.use(ToastService);

app.component('PvButton', PvButton);
app.component('PvInputText', PvInputText);
app.component('PvDataTable', PvDataTable);
app.component('PvColumn', PvColumn);
app.component('PvDialog', PvDialog);
app.component('PvToast', PvToast);

app.mount('#app');
