<div>
<hr>
<h1 data-spm-anchor-id="5aebb161.65e9fcb3.0.i48.70242a1anngFFs"><strong data-spm-anchor-id="5aebb161.65e9fcb3.0.i40.70242a1anngFFs">Order Integration API </strong> </h1>
<p><button class="w-max-full w-fit"><img src="https://img.shields.io/badge/.NET-8.0-blue" alt=".NET" class="rounded-lg" draggable="false" data-cy="image"></button>  <button class="w-max-full w-fit"><img src="https://img.shields.io/badge/Entity_Framework_Core-9.x-green" alt="EntityFrameworkCore" class="rounded-lg" draggable="false" data-cy="image"></button>  <button class="w-max-full w-fit"><img src="https://img.shields.io/badge/AutoMapper-latest-orange" alt="AutoMapper" class="rounded-lg" draggable="false" data-cy="image"></button>  </p>
<div class="my-2"></div>
<p>Este é um projeto de integração de pedidos que processa arquivos desnormalizados e os converte em uma estrutura normalizada. A aplicação é construída usando <strong>ASP.NET Core 8 </strong>, <strong>Entity Framework Core </strong> e <strong>SQL Server </strong>. </p>
<div class="my-2"></div>
<hr>
<h2><strong>Tabela de Conteúdo </strong> </h2>
<ol start="1">
   <li><a href="#descri%C3%A7%C3%A3o-do-projeto--" target="_blank" rel="nofollow">Descrição do Projeto </a></li>
   <li><a href="#estrutura-do-projeto--" target="_blank" rel="nofollow">Estrutura do Projeto </a></li>
   <li><a href="#pr%C3%A9-requisitos--" target="_blank" rel="nofollow">Pré-requisitos </a></li>
   <li><a href="#configura%C3%A7%C3%A3o-inicial--" target="_blank" rel="nofollow">Configuração Inicial </a></li>
   <li><a href="#executando-o-projeto--" target="_blank" rel="nofollow">Executando o Projeto </a></li>
   <li><a href="migra%C3%A7%C3%B5es-do-banco-de-dados--" target="_blank" rel="nofollow">Migrações do Banco de Dados </a></li>
   <li><a href="#endpoints-da-api--" target="_blank" rel="nofollow">Endpoints da API </a></li>
   <li><a href="#licen%C3%A7a--" target="_blank" rel="nofollow">Licença </a></li>
</ol>
<div class="my-2"></div>
<hr>
<h2><strong>Descrição do Projeto </strong> </h2>
<p>O objetivo deste projeto é criar uma API REST que: </p>
<ul>
   <li>Receba um arquivo desnormalizado contendo informações de usuários, pedidos e produtos.</li>
   <li>Processe o arquivo e normalize os dados em uma estrutura relacional.</li>
   <li>Armazene os dados em um banco de dados SQL Server.</li>
   <li>Exponha os dados normalizados por meio de endpoints JSON.</li>
</ul>
<div class="my-2"></div>
<hr>
<h2><strong data-spm-anchor-id="5aebb161.65efcb3.0.i42.70242a1anngFFs">Estrutura do Projeto </strong> </h2>
<div>
   <div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
      <div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white"></div>
      <div class="language- rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
         <div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
         <div id="code-textarea-2cd6b716-1e75-48cf-bde8-c8414c78d7c-1" class="h-full w-full code-textarea ">
            <div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
               <div class="cm-announced" aria-live="polite"></div>
               <div tabindex="-1" class="cm-scroller">
                  <div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true">
                     <div class="cm-line">/OrderIntegration</div>
                     <div class="cm-line">    /OrderIntegration.API          -&gt; API REST (Controladores, Configurações)</div>
                     <div class="cm-line">    /OrderIntegration.Core         -&gt; Lógica de negócio (DTOs, Serviços, Mapeamentos)</div>
                     <div class="cm-activeLine cm-line">    /OrderIntegration.Infrastructure -&gt; Integração com banco de dados (Repositórios, EF Core)</div>
                     <div class="cm-line">    /OrderIntegration.Domain       -&gt; Entidades e interfaces (Modelagem de domínio)</div>
                     <div class="cm-line">    /OrderIntegration.Tests        -&gt; Testes unitários e de integração</div>
                  </div>
                  <div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms; animation-name: cm-blink;">
                     <div class="cm-cursor cm-cursor-primary" style="left: 371.078px; top: 72.1719px; height: 19px;"></div>
                  </div>
                  <div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
               </div>
            </div>
         </div>
      </div>
      <div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-19" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
   </div>
</div>
<div class="my-2"></div>
<hr>
<h2><strong>Pré-requisitos </strong> </h2>
<p>Para executar este projeto, você precisa ter instalado: </p>
<div class="my-2"></div>
<ul>
   <li><a href="https://dotnet.microsoft.com/download/dotnet/8.0" target="_blank" rel="nofollow">.NET SDK 8 </a></li>
   <li><a href="https://www.microsoft.com/sql-server" target="_blank" rel="nofollow">SQL Server </a> ou <a href="https://www.microsoft.com/sql-server/sql-server-editions-express" target="_blank" rel="nofollow">SQL Server Express </a></li>
   <li><a href="https://visualstudio.microsoft.com/" target="_blank" rel="nofollow">Visual Studio 2022 </a> ou <a href="https://code.visualstudio.com/" target="_blank" rel="nofollow">VS Code </a> (opcional)</li>
</ul>
<div class="my-2"></div>
<hr>
<h2 data-spm-anchor-id="5aebb161.65e9fcb3.0.i52.70242a1anngFFs"><strong>Configuração Inicial </strong> </h2>
<ol start="1">
   <li data-spm-anchor-id="5aebb161.65e9fcb3.0.i49.70242a1anngFFs">
      <p><strong data-spm-anchor-id="5aebb161.65e9fcb3.0.i50.70242a1anngFFs">Clone o repositório </strong> </p>
      <div>
         <div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
            <div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">bash</div>
            <div class="language-bash rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
               <div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
               <div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-0-1" class="h-full w-full code-textarea ">
                  <div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
                     <div class="cm-announced" aria-live="polite"></div>
                     <div tabindex="-1" class="cm-scroller">
                        <div class="cm-gutters" aria-hidden="true" style="min-height: 52.7812px; position: sticky;">
                           <div class="cm-gutter cm-foldGutter">
                              <div class="cm-gutterElement cm-activeLineGutter" style="height: 22.3906px; margin-top: 4px;"></div>
                           </div>
                        </div>
                        <div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true" data-language="shell" aria-autocomplete="list">
                           <div class="cm-activeLine cm-line"><pre><code class="bash">git clone https://github.com/RafaelaCuoco/OrderIntegration.git
cd OrderIntegration</code></pre></div>
                        </div>
                        <div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
                           <div class="cm-cursor cm-cursor-primary" style="left: 36.7969px; top: 5px; height: 19px;"></div>
                        </div>
                        <div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
                     </div>
                  </div>
               </div>
            </div>
            <div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-0-1" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
         </div>
      </div>
   </li>
   <li>
      <p><strong data-spm-anchor-id="5aebb161.65e9fcb3.0.i51.70242a1anngFFs">Restaure as dependências </strong>
         Execute o seguinte comando na raiz do projeto para restaurar as dependências NuGet: 
      </p>
      <div>
         <div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
            <div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">bash</div>
            <div class="language-bash rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
               <div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
               <div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-1-1" class="h-full w-full code-textarea ">
                  <div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
                     <div class="cm-announced" aria-live="polite"></div>
                     <div tabindex="-1" class="cm-scroller">
                        <div class="cm-gutters" aria-hidden="true" style="min-height: 30.3906px; position: sticky;">
                           <div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true" data-language="shell" aria-autocomplete="list">
                              <div class="cm-activeLine cm-line"><pre><code class="bash">dotnet restore</code></pre></div>
                           </div>
                           <div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
                              <div class="cm-cursor cm-cursor-primary" style="left: 36.7969px; top: 5px; height: 19px;"></div>
                           </div>
                           <div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
                        </div>
                     </div>
                  </div>
               </div>
               <div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-1-1" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
            </div>
         </div>
   </li>
   <li>
   <p><strong>Configure a string de conexão </strong>
   Abra o arquivo <code class="codespan cursor-pointer">appsettings.json</code> no projeto <code class="codespan cursor-pointer">OrderIntegration.API</code> e configure a string de conexão para o SQL Server: 
   </p>
   <div class="my-2"></div>
   <div>
   <div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
   <div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">json</div>
   <div class="language-json rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
   <div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
   <div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-2-2" class="h-full w-full code-textarea ">
   <div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
   <div class="cm-announced" aria-live="polite"></div>
   <div tabindex="-1" class="cm-scroller">
   <div class="cm-gutters" aria-hidden="true" style="min-height: 75.1719px; position: sticky;">
   </div>
   <div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true" data-language="json">

   <div class="cm-line"></div>
      <div class="cm-activeLine cm-line"><pre><code class="json">{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=OrderIntegrationDb;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}</code></pre></div>
   </div>
   <div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
   <div class="cm-cursor cm-cursor-primary" style="left: 37px; top: 5px; height: 19px;"></div>
   </div>
   <div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
   </div>
   </div>
   </div>
   </div>
   <div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-2-2" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
   </div>
   </div>
   <div class="my-2"></div>
   <blockquote>
   <p>Substitua <code class="codespan cursor-pointer">SEU_SERVIDOR</code>, <code class="codespan cursor-pointer">SEU_USUARIO</code> e <code class="codespan cursor-pointer">SUA_SENHA</code> pelas suas credenciais do SQL Server. </p>
   </blockquote>
   </li>
   <li>
   <p><strong>Crie o banco de dados no SQL Server </strong>
   Em seu SQL Server Management Studio, crie o banco vazio para que o Entity Framework possa popular os dados: 
   </p>
   <div class="my-2"></div>
   <div>
   <div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
   <div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">SQL</div>
   <div class="language-json rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
   <div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
   <div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-2-2" class="h-full w-full code-textarea ">
   <div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
   <div class="cm-announced" aria-live="polite"></div>
   <div tabindex="-1" class="cm-scroller">
   <div class="cm-gutters" aria-hidden="true" style="min-height: 75.1719px; position: sticky;">
   </div>
   <div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true" data-language="json">

   <div class="cm-line"></div>
      <div class="cm-activeLine cm-line"><pre><code class="SQL">CREATE DATABASE OrderIntegrationDb;</code></pre></div>
   </div>
   <div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
   <div class="cm-cursor cm-cursor-primary" style="left: 37px; top: 5px; height: 19px;"></div>
   </div>
   <div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
   </div>
   </div>
   </div>
   </div>
   <div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-29-2-2" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
   </div>
   </div>
   </li>
</ol>
<div class="my-2"></div>
<hr>
<h2><strong>Executando o Projeto </strong> </h2>
<ol start="1">
<li>
<p><strong>Execute o projeto </strong>
Use o seguinte comando para iniciar a API: 
</p>
<div>
<div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
<div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">bash</div>
<div class="language-bash rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
<div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
<div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-33-0-1" class="h-full w-full code-textarea ">
<div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
<div class="cm-announced" aria-live="polite"></div>
<div tabindex="-1" class="cm-scroller">
<div class="cm-gutters" aria-hidden="true" style="min-height: 30.3906px; position: sticky;">
</div>
<div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true" data-language="shell" aria-autocomplete="list">
<div class="cm-activeLine cm-line"><pre><code class="bash">dotnet run --project OrderIntegration.API.csproj</code></pre></div>
</div>
<div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
<div class="cm-cursor cm-cursor-primary" style="left: 36.7969px; top: 5px; height: 19px;"></div>
</div>
<div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
</div>
</div>
</div>
</div>
<div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-33-0-1" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
</div>
</div>
<div class="my-2"></div>
<p>A API estará disponível em: <code class="codespan cursor-pointer">http://localhost:5000</code> ou <code class="codespan cursor-pointer">https://localhost:5001</code>. </p>
</li>
<li>
<p><strong>Teste a API </strong>
Use ferramentas como <a href="https://www.postman.com/" target="_blank" rel="nofollow">Postman </a> ou <a href="https://swagger.io/" target="_blank" rel="nofollow">Swagger </a> para testar os endpoints. 
</p>
</li>
</ol>
<div class="my-2"></div>
<hr>
<h2><strong>Migrações do Banco de Dados </strong> </h2>
<p>O projeto ja contem uma migration personalizada para popular o banco, siga os passos abaixo: </p>
<div class="my-2"></div>
<ol start="1">
<li>
<p><strong>Update-database da migration </strong> </p>
<div>
<div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
<div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">bash</div>
<div class="language-bash rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
<div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
<div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-39-0-1" class="h-full w-full code-textarea ">
<div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
<div class="cm-announced" aria-live="polite"></div>
<div tabindex="-1" class="cm-scroller">
<div class="cm-gutters" aria-hidden="true" style="min-height: 30.3906px; position: sticky;">
</div>
<div spellcheck="false" autocorrect="off" autocapitalize="off" writingsuggestions="false" translate="no" contenteditable="false" style="tab-size: 4;" class="cm-content" role="textbox" aria-multiline="true" data-language="shell" aria-autocomplete="list">
   <div class="cm-activeLine cm-line"><pre><code class="bash">dotnet ef update-database</code></pre></div>
</div>
<div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
<div class="cm-cursor cm-cursor-primary" style="left: 36.7969px; top: 5px; height: 19px;"></div>
</div>
<div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
</div>
</div>
</div>
</div>
<div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-39-0-1" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
</div>
</div>
</li>
</ol>
<div class="my-2"></div>
<hr>
<h2 data-spm-anchor-id="5aebb161.65e9fcb3.0.i46.70242a1anngFFs"><strong>Endpoints da API </strong> </h2>
<h3 data-spm-anchor-id="5aebb161.65e9fcb3.0.i47.70242a1anngFFs"><strong>1. Upload de Arquivo </strong> </h3>
<ul>
<li><strong>URL </strong>: <code class="codespan cursor-pointer">/api/orders/upload</code></li>
<li><strong>Método </strong>: <code class="codespan cursor-pointer">POST</code></li>
<li><strong>Descrição </strong>: Processa um arquivo desnormalizado e armazena os dados no banco de dados.</li>
<li>
<strong>Exemplo de Requisição </strong>:

<strong>Body </strong>: Envie um arquivo no formato multipart/form-data.
<div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">Text</div>
<div class="language-json rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
<div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
<div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-44-4-1" class="h-full w-full code-textarea ">
<div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
<div class="cm-announced" aria-live="polite"></div>
<div tabindex="-1" class="cm-scroller">
<div class="cm-activeLine cm-line"><pre><code class="Text">0000000001                                Rafaela Cuoco00000001230000000123       96.4720250225</code></pre></div>
</ul>
</li>
<ul><li>
<strong>Exemplo de Resposta </strong>:
<div>
<div class="relative my-2 flex flex-col rounded-lg" dir="ltr">
<div class="text-text-300 absolute pl-4 py-1.5 text-xs font-medium dark:text-white">json</div>
<div class="language-json rounded-t-lg -mt-8 rounded-b-lg overflow-hidden">
<div class="pt-7 bg-gray-50 dark:bg-gray-850"></div>
<div id="code-textarea-2cd6b716-1e75-48cf-bde8-c84149c78d7c-44-4-1" class="h-full w-full code-textarea ">
<div class="cm-editor ͼ1 ͼ3 ͼ4 ͼo">
<div class="cm-announced" aria-live="polite"></div>
<div tabindex="-1" class="cm-scroller">
<div class="cm-activeLine cm-line"><pre><code class="SQL">{
  "success": true,
  "message": "Processamento concluído com sucesso.",
  "data": [
    {
      "userId": 1,
      "name": "Rafaela Cuoco",
      "orders": [
        {
          "orderId": 123,
          "total": "96.47",
          "date": "2025-02-25",
          "products": [
            {
              "productId": 123,
              "value": "96.47"
            }
          ]
        }
      ]
    }
  ],
  "warnings": []
}</code></pre></div>
<div class="cm-layer cm-layer-above cm-cursorLayer" aria-hidden="true" style="z-index: 150; animation-duration: 1200ms;">
<div class="cm-cursor cm-cursor-primary" style="left: 42.5938px; top: 5px; height: 19px;"></div>
</div>
<div class="cm-layer cm-selectionLayer" aria-hidden="true" style="z-index: -2;"></div>
</div>
</div>
</div>
</div>
<div id="plt-canvas-2cd6b716-1e75-48cf-bde8-c84149c78d7c-44-4-1" class="bg-[#202123] text-white max-w-full overflow-x-auto scrollbar-hidden"></div>
</div>
</div>
</li>
</ul>
<div class="my-2"></div>
<hr>
<h2><strong>Licença </strong> </h2>
<p>Este projeto está licenciado sob a <a href="LICENSE" target="_blank" rel="nofollow">MIT License </a>. </p>
<div class="my-2"></div>
<hr>
</div>
