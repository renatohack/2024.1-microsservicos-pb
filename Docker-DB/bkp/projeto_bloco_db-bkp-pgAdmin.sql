PGDMP  ,    )                |            projeto_bloco    16.2    16.2                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16572    projeto_bloco    DATABASE     �   CREATE DATABASE projeto_bloco WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';
    DROP DATABASE projeto_bloco;
                postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                pg_database_owner    false            	           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   pg_database_owner    false    4            �            1259    16573    alunos    TABLE     s   CREATE TABLE public.alunos (
    aluno_id uuid NOT NULL,
    nome text NOT NULL,
    matricula integer NOT NULL
);
    DROP TABLE public.alunos;
       public         heap    postgres    false    4            �            1259    16578    alunos_matricula_seq    SEQUENCE     �   ALTER TABLE public.alunos ALTER COLUMN matricula ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.alunos_matricula_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    4    215            �            1259    16579    disciplinas    TABLE     �   CREATE TABLE public.disciplinas (
    disciplina_id uuid NOT NULL,
    nome text NOT NULL,
    numero_aulas smallint NOT NULL
);
    DROP TABLE public.disciplinas;
       public         heap    postgres    false    4            �            1259    16584 
   inscricoes    TABLE        CREATE TABLE public.inscricoes (
    inscricao_id uuid NOT NULL,
    ativa boolean NOT NULL,
    presenca smallint NOT NULL,
    nota_p1 numeric(3,2) NOT NULL,
    nota_p2 numeric(3,2) NOT NULL,
    nota_pf numeric(3,2) NOT NULL,
    aluno_id uuid NOT NULL,
    turma_id uuid NOT NULL
);
    DROP TABLE public.inscricoes;
       public         heap    postgres    false    4            �            1259    16587    professores    TABLE     \   CREATE TABLE public.professores (
    professor_id uuid NOT NULL,
    nome text NOT NULL
);
    DROP TABLE public.professores;
       public         heap    postgres    false    4            �            1259    16592    turmas    TABLE     j   CREATE TABLE public.turmas (
    turma_id uuid NOT NULL,
    professor_id uuid,
    disciplina_id uuid
);
    DROP TABLE public.turmas;
       public         heap    postgres    false    4            �          0    16573    alunos 
   TABLE DATA                 public          postgres    false    215          �          0    16579    disciplinas 
   TABLE DATA                 public          postgres    false    217   �                  0    16584 
   inscricoes 
   TABLE DATA                 public          postgres    false    218   �                 0    16587    professores 
   TABLE DATA                 public          postgres    false    219   �                 0    16592    turmas 
   TABLE DATA                 public          postgres    false    220   X        
           0    0    alunos_matricula_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.alunos_matricula_seq', 2, true);
          public          postgres    false    216            a           2606    16596    alunos alunos_pk 
   CONSTRAINT     T   ALTER TABLE ONLY public.alunos
    ADD CONSTRAINT alunos_pk PRIMARY KEY (aluno_id);
 :   ALTER TABLE ONLY public.alunos DROP CONSTRAINT alunos_pk;
       public            postgres    false    215            c           2606    16598    disciplinas disciplinas_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public.disciplinas
    ADD CONSTRAINT disciplinas_pkey PRIMARY KEY (disciplina_id);
 F   ALTER TABLE ONLY public.disciplinas DROP CONSTRAINT disciplinas_pkey;
       public            postgres    false    217            e           2606    16600    inscricoes inscricoes_pk 
   CONSTRAINT     `   ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_pk PRIMARY KEY (inscricao_id);
 B   ALTER TABLE ONLY public.inscricoes DROP CONSTRAINT inscricoes_pk;
       public            postgres    false    218            g           2606    16602    professores professores_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.professores
    ADD CONSTRAINT professores_pkey PRIMARY KEY (professor_id);
 F   ALTER TABLE ONLY public.professores DROP CONSTRAINT professores_pkey;
       public            postgres    false    219            i           2606    16604    turmas turmas_pk 
   CONSTRAINT     T   ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_pk PRIMARY KEY (turma_id);
 :   ALTER TABLE ONLY public.turmas DROP CONSTRAINT turmas_pk;
       public            postgres    false    220            j           2606    16605 #   inscricoes inscricoes_ref_alunos_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_ref_alunos_fk FOREIGN KEY (aluno_id) REFERENCES public.alunos(aluno_id) ON UPDATE CASCADE ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.inscricoes DROP CONSTRAINT inscricoes_ref_alunos_fk;
       public          postgres    false    215    218    4705            k           2606    16610 #   inscricoes inscricoes_ref_turmas_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.inscricoes
    ADD CONSTRAINT inscricoes_ref_turmas_fk FOREIGN KEY (turma_id) REFERENCES public.turmas(turma_id) ON UPDATE CASCADE ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.inscricoes DROP CONSTRAINT inscricoes_ref_turmas_fk;
       public          postgres    false    218    220    4713            l           2606    16615     turmas turmas_ref_disciplinas_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_ref_disciplinas_fk FOREIGN KEY (disciplina_id) REFERENCES public.disciplinas(disciplina_id) ON UPDATE CASCADE ON DELETE CASCADE;
 J   ALTER TABLE ONLY public.turmas DROP CONSTRAINT turmas_ref_disciplinas_fk;
       public          postgres    false    217    4707    220            m           2606    16620     turmas turmas_ref_professores_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.turmas
    ADD CONSTRAINT turmas_ref_professores_fk FOREIGN KEY (professor_id) REFERENCES public.professores(professor_id) ON UPDATE CASCADE ON DELETE SET NULL;
 J   ALTER TABLE ONLY public.turmas DROP CONSTRAINT turmas_ref_professores_fk;
       public          postgres    false    4711    220    219            �   �   x����
�@��W��,p�9d3�
�(5�U�sӰ�������}�GgeZT��*��d��n�������[A?<||���:\C^�E��:;Ay+����|M-a�&�	��0��b���K��ᶉF����0?���?oh��UL���d�0�THT[\,Ə=�nѰYɵR�      �   �   x�����0�w���PC��890�L]I{i�&����['} �sr��|M�շ�4m%ۮ'���yt���I���Y�ل�g�\�Oʧ�q���$1pQ1�-�j� J�Z ��r[a�
Mg$��;Ta�<=E����T+-)h!ù��8;" Ï��^&��"��إP�            x�Ő�j�@E{�:��1��T)\���6��̂���l���"q�*e���^����/�f�?>7�)����k�|�k��a:���n��Һ��r�!W�7z��;�;��=M�w�6�Tiռ=>�nͲMVGG��Y:�$)��8�N�`jks�d��y�Q��mCQ�Y�`P�NDd�	6�dsQ��9'^%�4�9#��hP6dT9��Ю�a�O̜�iUߏQ 8��3����?DH�J�a��  q>����bG��+�x�����cr�x�X|la�0         �   x��ͻ�0 Н��VH����Ɂ�	A#�jJ�7!QK ����p<�qmW�z������p��f^"��W��p�Ɯ=�3v�7�c)/����
�"o�~�WB�yK<g�9�l��*UV�hE�P�G�����#U�
��J�ҕ@]         �   x����j1E���MQ�C~����"PRh�n�-�0�6a���z�]���\����Y��7u����O���;/j�_Sݩ�|m�,�����t�L?�r�>_^?�'��D]=��0X��րv�Qs��iܩ�pl:�j� m�3Q�1[�n��ʡ�ɰ��}��1 ���s�%N�Y¸}�WA��ф��@j�R	H�2뺪yc��o����I
� ɻ���g^9A
(�@ɥW-��=E�%�g��V�?+6o     